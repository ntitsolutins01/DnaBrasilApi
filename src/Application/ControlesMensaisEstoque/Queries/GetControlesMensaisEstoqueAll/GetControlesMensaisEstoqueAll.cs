using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesMensaisEstoque.Queries.GetControlesMensaisEstoqueAll;
//[Authorize]
public record GetControlesMensaisEstoqueAllQuery : IRequest<List<ControleMensalEstoqueDto>>;

public class GetControlesMensaisEstoqueAllQueryHandler : IRequestHandler<GetControlesMensaisEstoqueAllQuery, List<ControleMensalEstoqueDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlesMensaisEstoqueAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ControleMensalEstoqueDto>> Handle(GetControlesMensaisEstoqueAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ControlesMensaisEstoque
            .AsNoTracking()
            .ProjectTo<ControleMensalEstoqueDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
