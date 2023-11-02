using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Application.Locais.Queries;

namespace DnaBrasil.Application.Locals.Queries.GetLocalsAll;
//[Authorize]
public record GetLocalsQuery : IRequest<List<LocalDto>>;

public class GetLocalsQueryHandler : IRequestHandler<GetLocalsQuery, List<LocalDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetLocalsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<LocalDto>> Handle(GetLocalsQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Locais
            .AsNoTracking()
            .ProjectTo<LocalDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
