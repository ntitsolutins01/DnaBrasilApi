using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Inventarios.Queries.GetInventarioById;

public record GetInventarioByIdQuery : IRequest<InventarioDto>
{
    public required int Id { get; init; }
}

public class GetInventarioByIdQueryHandler : IRequestHandler<GetInventarioByIdQuery, InventarioDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetInventarioByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<InventarioDto> Handle(GetInventarioByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Inventarios
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<InventarioDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
