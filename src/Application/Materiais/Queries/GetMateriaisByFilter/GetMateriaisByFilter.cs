using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Materiais.Queries.GetMateriaisByFilter;

public record GetMateriaisByFilterQuery : IRequest<List<MaterialIndexDto>>
{
    public MateriaisFilterDto? SearchFilter { get; init; }
}

public class GetMateriaisByFilterQueryHandler : IRequestHandler<GetMateriaisByFilterQuery, List<MaterialIndexDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMateriaisByFilterQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<MaterialIndexDto>> Handle(GetMateriaisByFilterQuery request, CancellationToken cancellationToken)
    {
        var Materiais = _context.Materiais
            .Include(r => r.TipoMaterial)
            .AsNoTracking();

        var result = FilterMateriais(Materiais, request.SearchFilter!, cancellationToken)
            .ProjectTo<MaterialIndexDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return await (result ?? throw new ArgumentNullException(nameof(result)));
    }

    private IQueryable<Material> FilterMateriais(IQueryable<Material> Materiais, MateriaisFilterDto search, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.Id))
        {
            Materiais = Materiais.Where(u => u.Id.ToString().Equals(search.Id));
        }

        if (!string.IsNullOrWhiteSpace(search.NomeMaterial))
        {
            Materiais = Materiais.Where(u => u.Descricao!.ToString().Contains(search.NomeMaterial));
        }

        if (!string.IsNullOrWhiteSpace(search.GrupoMaterialId))
        {
            Materiais = Materiais.Where(u => u.TipoMaterial.GrupoMaterial.Id.ToString().Equals(search.GrupoMaterialId));
        }

        if (!string.IsNullOrWhiteSpace(search.TipoMaterialId))
        {
            Materiais = Materiais.Where(u => u.TipoMaterial.Id.ToString().Equals(search.TipoMaterialId));
        }

        return Materiais;
    }
}
