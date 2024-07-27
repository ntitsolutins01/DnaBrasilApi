using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Contratos.Queries.GetContratosAll;
//[Authorize]
public record GetContratosAllQuery : IRequest<List<ContratoDto>>;

public class GetContratosAllQueryHandler : IRequestHandler<GetContratosAllQuery, List<ContratoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetContratosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ContratoDto>> Handle(GetContratosAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Contratos
            .AsNoTracking()
            .ProjectTo<ContratoDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
