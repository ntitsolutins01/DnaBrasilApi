using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TiposMateriais.Queries.GetTiposMateriaisAll;
//[Authorize]
public record GetTiposMateriaisAllQuery : IRequest<List<TipoMaterialDto>>;

public class GetTiposMateriaisAllQueryHandler : IRequestHandler<GetTiposMateriaisAllQuery, List<TipoMaterialDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTiposMateriaisAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TipoMaterialDto>> Handle(GetTiposMateriaisAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.TiposMateriais
            .AsNoTracking()
            .ProjectTo<TipoMaterialDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
