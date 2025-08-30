using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.FotosEvento.Queries.GetFotoEventoById;

public record GetFotoEventoByIdQuery : IRequest<List<FotoEventoDto>>
{
    public required int Id { get; init; }
}

public class GetFotoEventoByIdQueryHandler : IRequestHandler<GetFotoEventoByIdQuery, List<FotoEventoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetFotoEventoByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<FotoEventoDto>> Handle(GetFotoEventoByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.FotosEvento
            .Where(x => x.Evento.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<FotoEventoDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
