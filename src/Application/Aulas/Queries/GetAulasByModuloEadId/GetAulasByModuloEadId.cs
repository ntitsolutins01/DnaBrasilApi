using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Aulas.Queries.GetAulasByModuloEadId;

public record GetAulasByModuloEadIdQuery : IRequest<List<AulaDto>>
{
    public required int ModuloEadId { get; init; }
}

public class GetAulasByModuloEadIdQueryHandler : IRequestHandler<GetAulasByModuloEadIdQuery, List<AulaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAulasByModuloEadIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AulaDto>> Handle(GetAulasByModuloEadIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Aulas
            .Include(i => i.ModuloEad)
            .Where(x => x.ModuloEad.Id == request.ModuloEadId)
            .AsNoTracking()
            .ProjectTo<AulaDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
