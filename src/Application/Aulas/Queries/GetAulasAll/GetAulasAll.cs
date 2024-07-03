using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Aulas.Queries.GetAulasAll;
//[Authorize]
public record GetAulasAllQuery : IRequest<List<AulaDto>>;

public class GetAulasAllQueryHandler : IRequestHandler<GetAulasAllQuery, List<AulaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAulasAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AulaDto>> Handle(GetAulasAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Aulas
            .AsNoTracking()
            .ProjectTo<AulaDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
