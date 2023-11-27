using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Escolaridades.Queries.GetEscolaridadeById;

public record GetEscolaridadeByIdQuery : IRequest<EscolaridadeDto>
{
    public required int Id { get; init; }
}

public class GetEscolaridadeByIdQueryHandler : IRequestHandler<GetEscolaridadeByIdQuery, EscolaridadeDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEscolaridadeByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EscolaridadeDto> Handle(GetEscolaridadeByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Escolaridades
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<EscolaridadeDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
