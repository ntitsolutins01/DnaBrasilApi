using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.PlanosAulas.Queries.GetPlanosAulasAll;
//[Authorize]
public record GetPlanosAulasAllQuery : IRequest<List<PlanoAulaDto>>;

public class GetPlanosAulasAllQueryHandler : IRequestHandler<GetPlanosAulasAllQuery, List<PlanoAulaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPlanosAulasAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<PlanoAulaDto>> Handle(GetPlanosAulasAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.PlanosAulas
            .AsNoTracking()
            .ProjectTo<PlanoAulaDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result;
    }
}
