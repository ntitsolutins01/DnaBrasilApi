using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesMensaisEstoque.Queries.GetControlesMensaisEstoqueByMaterialId;

public record GetControlesMensaisEstoqueByMaterialIdQuery : IRequest<List<ControleMensalEstoqueDto>>
{
    public required int MaterialId { get; init; }
}

public class GetControlesMensaisEstoqueByMaterialIdQueryHandler : IRequestHandler<GetControlesMensaisEstoqueByMaterialIdQuery, List<ControleMensalEstoqueDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlesMensaisEstoqueByMaterialIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ControleMensalEstoqueDto>> Handle(GetControlesMensaisEstoqueByMaterialIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ControlesMensaisEstoque
            .Include(i=>i.Material)
            .Where(x => x.Material.Id == request.MaterialId)
            .AsNoTracking()
            .ProjectTo<ControleMensalEstoqueDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
