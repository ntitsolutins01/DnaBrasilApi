using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Series.Queries.GetTurmasByLocalidadeIdEtapaIdSerie;

public record GetTurmasByLocalidadeIdEtapaIdSerieQuery : IRequest<List<SerieDto>>
{
    public required int LocalidadeId { get; init; }
    public required int EtapaId { get; init; }
    public required string Serie { get; init; }
}

public class GetTurmasByLocalidadeIdEtapaIdSerieQueryHandler : IRequestHandler<GetTurmasByLocalidadeIdEtapaIdSerieQuery, List<SerieDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTurmasByLocalidadeIdEtapaIdSerieQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<SerieDto>> Handle(GetTurmasByLocalidadeIdEtapaIdSerieQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Series
            .Where(x => x.Localidade.Id == request.LocalidadeId && x.EtapaEnsino.Id == request.EtapaId && x.Nome == request.Serie)
            .AsNoTracking()
            .ProjectTo<SerieDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
