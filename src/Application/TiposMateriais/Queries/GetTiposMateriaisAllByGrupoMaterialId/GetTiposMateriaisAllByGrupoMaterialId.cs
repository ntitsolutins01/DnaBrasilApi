using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TiposMateriais.Queries.GetTiposMateriaisAllByGrupoMaterialId;

public record GetTiposMateriaisAllByGrupoMaterialIdQuery : IRequest<List<TipoMaterialDto>>
{
    public required int GrupoMaterialId { get; init; }
}

public class GetTiposMateriaisAllByGrupoMaterialIdQueryHandler : IRequestHandler<GetTiposMateriaisAllByGrupoMaterialIdQuery, List<TipoMaterialDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTiposMateriaisAllByGrupoMaterialIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TipoMaterialDto>> Handle(GetTiposMateriaisAllByGrupoMaterialIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.TiposMateriais
            .Include(i => i.GrupoMaterial)
            .Where(x => x.GrupoMaterial.Id == request.GrupoMaterialId)
            .AsNoTracking()
            .ProjectTo<TipoMaterialDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
