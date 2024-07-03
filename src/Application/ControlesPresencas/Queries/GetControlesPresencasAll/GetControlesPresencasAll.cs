using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesPresencas.Queries.GetControlesPresencasAll;
//[Authorize]
public record GetControlesPresencasAllQuery : IRequest<List<ControlePresencaDto>>;

public class GetControlesPresencasAllQueryHandler : IRequestHandler<GetControlesPresencasAllQuery, List<ControlePresencaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlesPresencasAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ControlePresencaDto>> Handle(GetControlesPresencasAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ControlesPresencas
            .Include(i => i.Evento)
            .Where(x => x.Evento == null)
            .AsNoTracking()
            .ProjectTo<ControlePresencaDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
