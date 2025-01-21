using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesMateriaisEstoquesSaidas.Queries.GetControlesMateriaisEstoquesSaidasByMaterialId;

public record GetControlesMateriaisEstoquesSaidasByMaterialIdQuery : IRequest<List<ControleMaterialEstoqueSaidaDto>>
{
    public required int MaterialId { get; init; }
}

public class GetControlesMateriaisEstoquesSaidasByMaterialIdQueryHandler : IRequestHandler<GetControlesMateriaisEstoquesSaidasByMaterialIdQuery, List<ControleMaterialEstoqueSaidaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlesMateriaisEstoquesSaidasByMaterialIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ControleMaterialEstoqueSaidaDto>> Handle(GetControlesMateriaisEstoquesSaidasByMaterialIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ControlesMateriaisEstoquesSaidas
            .Include(i=>i.Material)
            .Where(x => x.Material.Id == request.MaterialId)
            .AsNoTracking()
            .ProjectTo<ControleMaterialEstoqueSaidaDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
