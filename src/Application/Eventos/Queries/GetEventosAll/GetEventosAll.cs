using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Eventos.Queries.GetEventosAll;
//[Authorize]
public record GetEventosAllQuery : IRequest<List<EventoDto>>;

public class GetEventosAllQueryHandler : IRequestHandler<GetEventosAllQuery, List<EventoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEventosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EventoDto>> Handle(GetEventosAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Eventos
            .Include(i=>i.Fotos)
            .AsNoTracking()
            .ProjectTo<EventoDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
