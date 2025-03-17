using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Inventarios.Queries.GetInventariosAll;
//[Authorize]
public record GetInventariosAllQuery : IRequest<List<InventarioDto>>;

public class GetInventariosAllQueryHandler : IRequestHandler<GetInventariosAllQuery, List<InventarioDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetInventariosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<InventarioDto>> Handle(GetInventariosAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Inventarios
            .AsNoTracking()
            .ProjectTo<InventarioDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
