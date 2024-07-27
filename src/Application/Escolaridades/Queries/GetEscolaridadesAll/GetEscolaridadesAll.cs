using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Escolaridades.Queries.GetEscolaridadesAll;
//[Authorize]
public record GerEscolaridadesAllQuery : IRequest<List<EscolaridadeDto>>;

public class GerEscolaridadesAllQueryHandler : IRequestHandler<GerEscolaridadesAllQuery, List<EscolaridadeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GerEscolaridadesAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EscolaridadeDto>> Handle(GerEscolaridadesAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Escolaridades
            .AsNoTracking()
            .ProjectTo<EscolaridadeDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
