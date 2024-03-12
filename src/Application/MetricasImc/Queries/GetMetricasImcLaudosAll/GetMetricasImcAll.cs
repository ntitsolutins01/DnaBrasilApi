using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.MetricasImc.Queries.GetMetricasImcLaudosAll;
//[Authorize]
public record GetMetricasImcAllQuery : IRequest<List<MetricaImcDto>>;

public class GetMetricasImcAllQueryHandler : IRequestHandler<GetMetricasImcAllQuery, List<MetricaImcDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMetricasImcAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<MetricaImcDto>> Handle(GetMetricasImcAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.MetricasImc
            .AsNoTracking()
            .ProjectTo<MetricaImcDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Idade)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
