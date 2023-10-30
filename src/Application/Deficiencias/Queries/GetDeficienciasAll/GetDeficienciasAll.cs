using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Deficiencias.Queries.GetDeficienciasAll;
//[Authorize]
public record GetDeficienciasQuery : IRequest<List<DeficienciaDto>>;

public class GetDeficienciasQueryHandler : IRequestHandler<GetDeficienciasQuery, List<DeficienciaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDeficienciasQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<DeficienciaDto>> Handle(GetDeficienciasQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Deficiencias
            .AsNoTracking()
            .ProjectTo<DeficienciaDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
