using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Estados.Queries.GetEstadosAll;
//[Authorize]
public record GetEstadosQuery : IRequest<List<EstadoDto>>;

public class GetEstadosQueryHandler : IRequestHandler<GetEstadosQuery, List<EstadoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEstadosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EstadoDto>> Handle(GetEstadosQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Estados
            .AsNoTracking()
            .ProjectTo<EstadoDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);
        
        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}

