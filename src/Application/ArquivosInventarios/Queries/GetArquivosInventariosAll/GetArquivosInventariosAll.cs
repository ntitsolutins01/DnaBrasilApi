using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ArquivosInventarios.Queries.GetArquivosInventariosAll;
//[Authorize]
public record GetArquivosInventariosAllQuery : IRequest<List<ArquivosInventarioDto>>;

public class GetArquivosInventariosAllQueryHandler : IRequestHandler<GetArquivosInventariosAllQuery, List<ArquivosInventarioDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetArquivosInventariosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ArquivosInventarioDto>> Handle(GetArquivosInventariosAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ArquivosInventarios
            .AsNoTracking()
            .ProjectTo<ArquivosInventarioDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
