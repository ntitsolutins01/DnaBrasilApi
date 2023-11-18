using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Parceiros.Queries.GetParceiroAll;
//[Authorize]
public record GetParceirosAllQuery : IRequest<List<ParceiroDto>>;

public class GetParceirosAllQueryHandler : IRequestHandler<GetParceirosAllQuery, List<ParceiroDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetParceirosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ParceiroDto>> Handle(GetParceirosAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Parceiros
            .AsNoTracking()
            .ProjectTo<ParceiroDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
