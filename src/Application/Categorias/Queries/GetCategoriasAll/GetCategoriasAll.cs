using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Categorias.Queries.GetCategoriasAll;
//[Authorize]
public record GetCategoriasAllQuery : IRequest<List<CategoriaDto>>;

public class GetCategoriasAllQueryHandler : IRequestHandler<GetCategoriasAllQuery, List<CategoriaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCategoriasAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CategoriaDto>> Handle(GetCategoriasAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Categorias
            .AsNoTracking()
            .ProjectTo<CategoriaDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
