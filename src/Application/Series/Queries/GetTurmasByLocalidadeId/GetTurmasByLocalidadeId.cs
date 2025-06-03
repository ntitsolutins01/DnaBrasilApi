using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Series.Queries.GetTurmasByLocalidadeId;

public record GetTurmasByLocalidadeIdQuery : IRequest<List<SerieDto>>
{
    public required int LocalidadeId { get; init; }
}

public class GetTurmasByLocalidadeIdQueryHandler : IRequestHandler<GetTurmasByLocalidadeIdQuery, List<SerieDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTurmasByLocalidadeIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<SerieDto>> Handle(GetTurmasByLocalidadeIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Series
            .Where(x => x.Localidade.Id == request.LocalidadeId)
            .AsNoTracking()
            .ProjectTo<SerieDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
