using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Estados.Queries.GetEstadosAll;
//[Authorize]
public record GetEstadosAllQuery : IRequest<List<EstadoDto>>;

public class GetEstadosAllQueryHandler : IRequestHandler<GetEstadosAllQuery, List<EstadoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEstadosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EstadoDto>> Handle(GetEstadosAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Estados
            .AsNoTracking()
            .ProjectTo<EstadoDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);
        
        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}

