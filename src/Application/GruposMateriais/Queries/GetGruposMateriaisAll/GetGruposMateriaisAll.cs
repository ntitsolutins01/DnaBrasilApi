using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.GruposMateriais.Queries.GetGruposMateriaisAll;
//[Authorize]
public record GetGruposMateriaisAllQuery : IRequest<List<GrupoMaterialDto>>;

public class GetGruposMateriaisAllQueryHandler : IRequestHandler<GetGruposMateriaisAllQuery, List<GrupoMaterialDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetGruposMateriaisAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GrupoMaterialDto>> Handle(GetGruposMateriaisAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.GruposMateriais
            .AsNoTracking()
            .ProjectTo<GrupoMaterialDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
