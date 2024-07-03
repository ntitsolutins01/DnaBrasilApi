using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesPresencas.Queries.GetControlesPresencasByEventoId;

public record GetControlesPresencasByEventoIdQuery : IRequest<List<ControlePresencaDto>>
{
    public required int EventoId { get; init; }
}

public class GetControlesPresencasByEventoIdQueryHandler : IRequestHandler<GetControlesPresencasByEventoIdQuery, List<ControlePresencaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlesPresencasByEventoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ControlePresencaDto>> Handle(GetControlesPresencasByEventoIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ControlesPresencas
            .Where(x => x.Evento != null && x.Evento.Id == request.EventoId)
            .AsNoTracking()
            .ProjectTo<ControlePresencaDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
