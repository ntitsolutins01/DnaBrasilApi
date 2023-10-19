using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Municipios.Queries.GetMunicipiosByUf;
public record GetMunicipiosByUfQuery : IRequest<List<MunicipioDto>>;

public class GetMunicipiosByUfQueryHandler : IRequestHandler<GetMunicipiosByUfQuery, List<MunicipioDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMunicipiosByUfQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<MunicipioDto>> Handle(GetMunicipiosByUfQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Municipios
            .AsNoTracking()
            .ProjectTo<MunicipioDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
