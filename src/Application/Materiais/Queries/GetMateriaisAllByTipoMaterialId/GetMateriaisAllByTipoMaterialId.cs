using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Materiais.Queries.GetMateriaisAllByTipoMaterialId;

public record GetMateriaisAllByTipoMaterialIdQuery : IRequest<List<MaterialDto>>
{
    public required int TipoMaterialId { get; init; }
}

public class GetMateriaisAllByTipoMaterialIdQueryHandler : IRequestHandler<GetMateriaisAllByTipoMaterialIdQuery, List<MaterialDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMateriaisAllByTipoMaterialIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<MaterialDto>> Handle(GetMateriaisAllByTipoMaterialIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Materiais
            .Include(i => i.TipoMaterial)
            .Where(x => x.TipoMaterial.Id == request.TipoMaterialId)
            .AsNoTracking()
            .ProjectTo<MaterialDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
