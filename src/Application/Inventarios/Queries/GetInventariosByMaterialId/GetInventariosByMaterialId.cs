using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Inventarios.Queries.GetInventariosByMaterialId;

public record GetInventariosByMaterialIdQuery : IRequest<List<InventarioDto>>
{
    public required int MaterialId { get; init; }
}

public class GetInventariosByMaterialIdQueryHandler : IRequestHandler<GetInventariosByMaterialIdQuery, List<InventarioDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetInventariosByMaterialIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<InventarioDto>> Handle(GetInventariosByMaterialIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Inventarios
            .Include(i => i.Material)
            .Where(x => x.Material.Id == request.MaterialId)
            .AsNoTracking()
            .ProjectTo<InventarioDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
