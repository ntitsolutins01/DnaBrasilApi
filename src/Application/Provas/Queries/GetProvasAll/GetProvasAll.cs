using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Provas.Queries.GetProvasAll;
//[Authorize]
public record GetProvasAllQuery : IRequest<List<ProvaDto>>;

public class GetProvasAllQueryHandler : IRequestHandler<GetProvasAllQuery, List<ProvaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProvasAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ProvaDto>> Handle(GetProvasAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Provas
            .AsNoTracking()
            .ProjectTo<ProvaDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
