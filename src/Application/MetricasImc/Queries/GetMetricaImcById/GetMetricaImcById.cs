using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.MetricasImc.Queries.GetMetricaImcById;

public record GetMetricaImcByIdQuery : IRequest<MetricaImcDto>
{
    public required int Id { get; init; }
}

public class GetMetricaImcByIdQueryHandler : IRequestHandler<GetMetricaImcByIdQuery, MetricaImcDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMetricaImcByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<MetricaImcDto> Handle(GetMetricaImcByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.MetricasImc
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<MetricaImcDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
