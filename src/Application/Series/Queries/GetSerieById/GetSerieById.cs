using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Series.Queries.GetSerieById;

public record GetSerieByIdQuery : IRequest<SerieDto>
{
    public required int Id { get; init; }
}

public class GetSerieByIdQueryHandler : IRequestHandler<GetSerieByIdQuery, SerieDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSerieByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SerieDto> Handle(GetSerieByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Series
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<SerieDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
