using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Series.Querries.GetSeriesAll;
//[Authorize]
public record GetSerieQuery : IRequest<List<SerieDto>>;

public class GetSerieQueryHandler : IRequestHandler<GetSerieQuery, List<SerieDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSerieQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<SerieDto>> Handle(GetSerieQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Series
            .AsNoTracking()
            .ProjectTo<SerieDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
