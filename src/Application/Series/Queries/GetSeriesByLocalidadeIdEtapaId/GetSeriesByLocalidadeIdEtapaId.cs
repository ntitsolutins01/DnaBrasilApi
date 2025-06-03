using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Series.Queries.GetSeriesByLocalidadeIdEtapaId;

public record GetSeriesByLocalidadeIdEtapaIdQuery : IRequest<List<SerieDto>>
{
    public required int LocalidadeId { get; init; }
    public required int EtapaId { get; init; }
}

public class GetSeriesByLocalidadeIdEtapaIdQueryHandler : IRequestHandler<GetSeriesByLocalidadeIdEtapaIdQuery, List<SerieDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSeriesByLocalidadeIdEtapaIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<SerieDto>> Handle(GetSeriesByLocalidadeIdEtapaIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Series
            .Where(x => x.Localidade.Id == request.LocalidadeId && x.EtapaEnsino.Id == request.EtapaId)
            .AsNoTracking()
            .ProjectTo<SerieDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
