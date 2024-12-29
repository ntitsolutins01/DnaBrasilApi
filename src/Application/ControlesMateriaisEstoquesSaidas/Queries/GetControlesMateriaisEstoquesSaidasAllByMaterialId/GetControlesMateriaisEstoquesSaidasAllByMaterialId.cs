using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesMateriaisEstoquesSaidas.Queries.GetControlesMateriaisEstoquesSaidasAllByMaterialId;

public record GetControlesMateriaisEstoquesSaidasAllByMaterialIdQuery : IRequest<List<ControleMaterialEstoqueSaidaDto>>
{
    public required int MaterialId { get; init; }
}

public class GetControlesMateriaisEstoquesSaidasAllByMaterialIdQueryHandler : IRequestHandler<GetControlesMateriaisEstoquesSaidasAllByMaterialIdQuery, List<ControleMaterialEstoqueSaidaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlesMateriaisEstoquesSaidasAllByMaterialIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ControleMaterialEstoqueSaidaDto>> Handle(GetControlesMateriaisEstoquesSaidasAllByMaterialIdQuery request, CancellationToken cancellationToken)
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
