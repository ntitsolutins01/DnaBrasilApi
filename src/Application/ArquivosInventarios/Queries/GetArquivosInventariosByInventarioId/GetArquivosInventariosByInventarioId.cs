using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ArquivosInventarios.Queries.GetArquivosInventariosByInventarioId;

public record GetArquivosInventariosByInventarioIdQuery : IRequest<List<ArquivosInventarioDto>>
{
    public required int InventarioId { get; init; }
}

public class GetArquivosInventariosByInventarioIdQueryHandler : IRequestHandler<GetArquivosInventariosByInventarioIdQuery, List<ArquivosInventarioDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetArquivosInventariosByInventarioIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ArquivosInventarioDto>> Handle(GetArquivosInventariosByInventarioIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ArquivosInventarios
            .Include(i => i.Inventario)
            .Where(x => x.Inventario.Id == request.InventarioId)
            .AsNoTracking()
            .ProjectTo<ArquivosInventarioDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
