using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Aulas.Queries.GetAulaById;

public record GetAulaByIdQuery : IRequest<AulaDto>
{
    public required int Id { get; init; }
}

public class GetAulaByIdQueryHandler : IRequestHandler<GetAulaByIdQuery, AulaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAulaByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AulaDto> Handle(GetAulaByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Aulas
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<AulaDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
