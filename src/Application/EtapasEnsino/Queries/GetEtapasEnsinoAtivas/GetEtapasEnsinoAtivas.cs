using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.EtapasEnsino.Queries.GetEtapasEnsinoAtivas;
//[Authorize]
public record GetEtapasEnsinoAtivasQuery : IRequest<List<EtapaEnsinoDto>>;

public class GetEtapasEnsinoAtivasQueryHandler : IRequestHandler<GetEtapasEnsinoAtivasQuery, List<EtapaEnsinoDto>>
{
  private readonly IApplicationDbContext _context;
  private readonly IMapper _mapper;

  public GetEtapasEnsinoAtivasQueryHandler(IApplicationDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<List<EtapaEnsinoDto>> Handle(GetEtapasEnsinoAtivasQuery request, CancellationToken cancellationToken)
  {
    var result = await _context.EtapasEnsino
        .Where(x => x.Status == true)
        .AsNoTracking()
        .ProjectTo<EtapaEnsinoDto>(_mapper.ConfigurationProvider)
        .OrderBy(t => t.Nome)

        .ToListAsync(cancellationToken);

    return result == null ? throw new ArgumentNullException(nameof(result)) : result;
  }
}
