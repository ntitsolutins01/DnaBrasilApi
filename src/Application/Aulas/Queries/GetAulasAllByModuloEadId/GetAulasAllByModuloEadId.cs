using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Aulas.Queries.GetAulasAllByModuloEadId;

public record GetAulasAllByModuloEadIdQuery : IRequest<List<AulaDto>>
{
    public required int ModuloEadId { get; init; }
}

public class GetAulasAllByModuloEadIdQueryHandler : IRequestHandler<GetAulasAllByModuloEadIdQuery, List<AulaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAulasAllByModuloEadIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AulaDto>> Handle(GetAulasAllByModuloEadIdQuery request, CancellationToken cancellationToken)
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
