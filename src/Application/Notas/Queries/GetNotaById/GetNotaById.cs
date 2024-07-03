using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Notas.Queries.GetNotaById;

public record GetNotaByIdQuery : IRequest<NotaDto>
{
    public required int Id { get; init; }
}

public class GetNotaByIdQueryHandler : IRequestHandler<GetNotaByIdQuery, NotaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetNotaByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<NotaDto> Handle(GetNotaByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Notas
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<NotaDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
