using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Perfis.Queries.GetPerfisAll;
//[Authorize]
public record GetPerfisAllQuery : IRequest<List<PerfilDto>>;

public class GetPerfisAllQueryHandler : IRequestHandler<GetPerfisAllQuery, List<PerfilDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPerfisAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<PerfilDto>> Handle(GetPerfisAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Perfis
            .AsNoTracking()
            .ProjectTo<PerfilDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
