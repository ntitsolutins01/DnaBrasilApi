using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Estados.Queries.GetEstadoByUf;
//[Authorize]
public record GetEstadoByUfQuery : IRequest<EstadoDto>
{
    public required string Uf { get; init; }
}

public class GetEstadoByUfQueryHandler : IRequestHandler<GetEstadoByUfQuery, EstadoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEstadoByUfQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EstadoDto> Handle(GetEstadoByUfQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Estados
            .Where(x => x.Sigla == request.Uf)
            .AsNoTracking()
            .ProjectTo<EstadoDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .FirstOrDefaultAsync(cancellationToken);
        
        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}

