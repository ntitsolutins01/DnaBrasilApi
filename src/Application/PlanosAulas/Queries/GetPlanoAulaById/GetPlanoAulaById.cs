using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.PlanosAulas.Queries.GetPlanoAulaById;

public record GetPlanoAulaByIdQuery : IRequest<PlanoAulaDto>
{
    public required int Id { get; init; }
}

public class GetPlanoAulaByIdQueryHandler : IRequestHandler<GetPlanoAulaByIdQuery, PlanoAulaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPlanoAulaByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PlanoAulaDto> Handle(GetPlanoAulaByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.PlanosAulas
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<PlanoAulaDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
