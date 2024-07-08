using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.FotosEvento.Queries.GetFotosAllByEventoId;
//[Authorize]
public record GetFotosAllByEventoIdQuery : IRequest<List<FotoEventoDto>>
{
    public required int EventoId { get; init; }
}

public class GetFotosAllByEventoIdQueryHandler : IRequestHandler<GetFotosAllByEventoIdQuery, List<FotoEventoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetFotosAllByEventoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<FotoEventoDto>> Handle(GetFotosAllByEventoIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.FotosEvento
            .Where(x => x.Evento.Id == request.EventoId)
            .AsNoTracking()
            .ProjectTo<FotoEventoDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
