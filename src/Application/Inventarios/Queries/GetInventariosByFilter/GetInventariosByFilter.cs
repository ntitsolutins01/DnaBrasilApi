using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Inventarios.Queries.GetInventariosByFilter;

public record GetInventariosByFilterQuery : IRequest<List<InventarioIndexDto>>
{
    public InventariosFilterDto? SearchFilter { get; init; }
}

public class GetInventariosByFilterQueryHandler : IRequestHandler<GetInventariosByFilterQuery, List<InventarioIndexDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetInventariosByFilterQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<InventarioIndexDto>> Handle(GetInventariosByFilterQuery request, CancellationToken cancellationToken)
    {
        var Inventarios = _context.Inventarios
            .Include(r => r.Material)
            .AsNoTracking();

        var result = FilterInventarios(Inventarios, request.SearchFilter!, cancellationToken)
            .ProjectTo<InventarioIndexDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return await (result ?? throw new ArgumentNullException(nameof(result)));
    }

    private IQueryable<Inventario> FilterInventarios(IQueryable<Inventario> Inventarios, InventariosFilterDto search, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.Id))
        {
            Inventarios = Inventarios.Where(u => u.Id.ToString().Equals(search.Id));
        }

        if (!string.IsNullOrWhiteSpace(search.NomeMaterial))
        {
            Inventarios = Inventarios.Where(u => u.Material.Descricao.ToString().Contains(search.NomeMaterial));
        }

        if (!string.IsNullOrWhiteSpace(search.LocalidadeId))
        {
            Inventarios = Inventarios.Where(u => u.Localidade.Id.ToString().Contains(search.LocalidadeId));
        }

        if (!string.IsNullOrWhiteSpace(search.GrupoMaterialId))
        {
            Inventarios = Inventarios.Where(u => u.Material.TipoMaterial.GrupoMaterial.Id.ToString().Equals(search.GrupoMaterialId));
        }

        if (!string.IsNullOrWhiteSpace(search.TipoMaterialId))
        {
            Inventarios = Inventarios.Where(u => u.Material.TipoMaterial.Id.ToString().Equals(search.NomeMaterial));
        }

        return Inventarios;
    }
}
