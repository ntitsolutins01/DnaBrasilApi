using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Inventarios.Queries.GetInventariosByLocalidadeId;

public record GetInventariosByLocalidadeIdQuery : IRequest<List<InventarioDto>>
{
    public required int LocalidadeId { get; init; }
}

public class GetInventariosByLocalidadeIdQueryHandler : IRequestHandler<GetInventariosByLocalidadeIdQuery, List<InventarioDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetInventariosByLocalidadeIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<InventarioDto>> Handle(GetInventariosByLocalidadeIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Inventarios
            .Include(i => i.Localidade)
            .Where(x => x.Localidade.Id == request.LocalidadeId)
            .AsNoTracking()
            .ProjectTo<InventarioDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
