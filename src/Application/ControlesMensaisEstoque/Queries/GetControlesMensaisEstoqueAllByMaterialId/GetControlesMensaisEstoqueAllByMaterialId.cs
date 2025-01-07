using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesMensaisEstoque.Queries.GetControlesMensaisEstoqueAllByMaterialId;

public record GetControlesMensaisEstoqueAllByMaterialIdQuery : IRequest<List<ControleMensalEstoqueDto>>
{
    public required int MaterialId { get; init; }
}

public class GetControlesMensaisEstoqueAllByMaterialIdQueryHandler : IRequestHandler<GetControlesMensaisEstoqueAllByMaterialIdQuery, List<ControleMensalEstoqueDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlesMensaisEstoqueAllByMaterialIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ControleMensalEstoqueDto>> Handle(GetControlesMensaisEstoqueAllByMaterialIdQuery request, CancellationToken cancellationToken)
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
