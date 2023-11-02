using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Application.Locais.Queries;

namespace DnaBrasil.Application.Municipios.Queries.GetMunicipiosAll;
//[Authorize]
public record GetMunicipioQuery : IRequest<List<MunicipioDto>>;

public class GetMunicipioQueryHandler : IRequestHandler<GetMunicipioQuery, List<MunicipioDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMunicipioQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<MunicipioDto>> Handle(GetMunicipioQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Municipios
            .AsNoTracking()
            .ProjectTo<MunicipioDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
