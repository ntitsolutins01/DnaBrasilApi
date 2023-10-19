using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Application.Municipios.Queries.GetMunicipiosAll;

namespace DnaBrasil.Application.Municipios.Queries.GetMunicipiosAll;
//[Authorize]
public record GetMunicipiosQuery : IRequest<List<MunicipioDto>>;

public class GetMunicipiosQueryHandler : IRequestHandler<GetMunicipiosQuery, List<MunicipioDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMunicipiosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<MunicipioDto>> Handle(GetMunicipiosQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Municipios
            .AsNoTracking()
            .ProjectTo<MunicipioDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}

