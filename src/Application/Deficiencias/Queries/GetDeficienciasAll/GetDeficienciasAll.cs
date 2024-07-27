using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Deficiencias.Queries.GetDeficienciasAll;
//[Authorize]
public record GetDeficienciasAllQuery : IRequest<List<DeficienciaDto>>;

public class GetDeficienciasAllQueryHandler : IRequestHandler<GetDeficienciasAllQuery, List<DeficienciaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDeficienciasAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<DeficienciaDto>> Handle(GetDeficienciasAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Deficiencias
            .AsNoTracking()
            .ProjectTo<DeficienciaDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
