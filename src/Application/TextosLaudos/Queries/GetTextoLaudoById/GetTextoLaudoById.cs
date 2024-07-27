using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TextosLaudos.Queries.GetTextoLaudoById;

public record GetTextoLaudoByIdQuery : IRequest<TextoLaudoDto>
{
    public required int Id { get; init; }
}

public class GetTextoLaudoByIdQueryHandler : IRequestHandler<GetTextoLaudoByIdQuery, TextoLaudoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTextoLaudoByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TextoLaudoDto> Handle(GetTextoLaudoByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.TextosLaudos
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<TextoLaudoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
