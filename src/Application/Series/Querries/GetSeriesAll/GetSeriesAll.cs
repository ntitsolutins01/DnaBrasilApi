using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Series.Querries.GetSeriesAll;
//[Authorize]
public record GetSeriesAllQuery : IRequest<List<SerieDto>>;

public class GetSeriesAllQueryHandler : IRequestHandler<GetSeriesAllQuery, List<SerieDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSeriesAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<SerieDto>> Handle(GetSeriesAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Series
            .AsNoTracking()
            .ProjectTo<SerieDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
