using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.EtapasEnsino.Queries.GetEtapasEnsinoAll;
//[Authorize]
public record GetEtapasEnsinoAllQuery : IRequest<List<EtapaEnsinoDto>>;

public class GetEtapasEnsinoAllQueryHandler : IRequestHandler<GetEtapasEnsinoAllQuery, List<EtapaEnsinoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEtapasEnsinoAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EtapaEnsinoDto>> Handle(GetEtapasEnsinoAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.EtapasEnsino
            .AsNoTracking()
            .ProjectTo<EtapaEnsinoDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
