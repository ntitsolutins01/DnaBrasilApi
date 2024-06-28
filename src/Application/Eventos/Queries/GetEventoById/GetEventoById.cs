using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Eventos.Queries.GetEventoById;

public record GetEventoByIdQuery : IRequest<EventoDto>
{
    public required int Id { get; init; }
}

public class GetEventoByIdQueryHandler : IRequestHandler<GetEventoByIdQuery, EventoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEventoByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EventoDto> Handle(GetEventoByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Eventos
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<EventoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
