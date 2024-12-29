using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesMateriaisEstoquesSaidas.Queries.GetControlesMateriaisEstoquesSaidasAll;
//[Authorize]
public record GetControlesMateriaisEstoquesSaidasAllQuery : IRequest<List<ControleMaterialEstoqueSaidaDto>>;

public class GetControlesMateriaisEstoquesSaidasAllQueryHandler : IRequestHandler<GetControlesMateriaisEstoquesSaidasAllQuery, List<ControleMaterialEstoqueSaidaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlesMateriaisEstoquesSaidasAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ControleMaterialEstoqueSaidaDto>> Handle(GetControlesMateriaisEstoquesSaidasAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ControlesMateriaisEstoquesSaidas
            .AsNoTracking()
            .ProjectTo<ControleMaterialEstoqueSaidaDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
