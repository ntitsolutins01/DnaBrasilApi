using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Ambientes.Queries.GetAmbientesAll;
//[Authorize]
public record GetAmbientesQuery : IRequest<List<AmbienteDto>>;

public class GetAmbientesQueryHandler : IRequestHandler<GetAmbientesQuery, List<AmbienteDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAmbientesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AmbienteDto>> Handle(GetAmbientesQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Ambientes
            .AsNoTracking()
            .ProjectTo<AmbienteDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
