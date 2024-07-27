using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Fomentos.Queries.GetFomentosAll;
//[Authorize]
public record GetFomentosAllQuery : IRequest<List<FomentoDto>>;

public class GetFomentosAllQueryHandler : IRequestHandler<GetFomentosAllQuery, List<FomentoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetFomentosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<FomentoDto>> Handle(GetFomentosAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Fomentos
            .AsNoTracking()
            .ProjectTo<FomentoDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
