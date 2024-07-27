using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TiposParcerias.Queries.GetTiposParceriasAll;
//[Authorize]
public record GetTiposParceriasQuery : IRequest<List<TipoParceriaDto>>;

public class GetTiposParceriasQueryHandler : IRequestHandler<GetTiposParceriasQuery, List<TipoParceriaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTiposParceriasQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TipoParceriaDto>> Handle(GetTiposParceriasQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.TiposParcerias
            .AsNoTracking()
            .ProjectTo<TipoParceriaDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
