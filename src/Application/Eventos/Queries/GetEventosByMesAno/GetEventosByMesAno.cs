using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Eventos.Queries.GetEventosByMesAno;

public record GetEventosByMesAnoQuery : IRequest<List<EventoDto>>
{
    public required int Mes { get; init; }
    public required int Ano { get; init; }
}

public class GetEventosByMesAnoQueryHandler : IRequestHandler<GetEventosByMesAnoQuery, List<EventoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEventosByMesAnoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EventoDto>> Handle(GetEventosByMesAnoQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Eventos
            .Where(x => x.DataEvento.Month == request.Mes & x.DataEvento.Year == request.Ano)
            .AsNoTracking()
            .ProjectTo<EventoDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
