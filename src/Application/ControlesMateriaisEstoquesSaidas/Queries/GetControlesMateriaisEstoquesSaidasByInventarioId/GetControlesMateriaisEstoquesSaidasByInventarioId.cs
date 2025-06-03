using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesMateriaisEstoquesSaidas.Queries.GetControlesMateriaisEstoquesSaidasByInventarioId;

public record GetControlesMateriaisEstoquesSaidasByInventarioIdQuery : IRequest<List<ControleMaterialEstoqueSaidaDto>>
{
    public required int InventarioId { get; init; }
}

public class GetControlesMateriaisEstoquesSaidasByInventarioIdQueryHandler : IRequestHandler<GetControlesMateriaisEstoquesSaidasByInventarioIdQuery, List<ControleMaterialEstoqueSaidaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlesMateriaisEstoquesSaidasByInventarioIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ControleMaterialEstoqueSaidaDto>> Handle(GetControlesMateriaisEstoquesSaidasByInventarioIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ControlesMateriaisEstoquesSaidas
            .Include(i => i.Inventario)
            .Where(x => x.Inventario.Id == request.InventarioId)
            .AsNoTracking()
            .ProjectTo<ControleMaterialEstoqueSaidaDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
