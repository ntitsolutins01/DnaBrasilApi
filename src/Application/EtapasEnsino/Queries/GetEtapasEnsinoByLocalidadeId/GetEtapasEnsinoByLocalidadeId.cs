using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.EtapasEnsino.Queries.GetEtapasEnsinoByLocalidadeId;

public record GetEtapasEnsinoByLocalidadeIdQuery : IRequest<EtapaEnsinoDto>
{
    public required int LocalidadeId { get; init; }
}

public class GetEtapasEnsinoByLocalidadeIdQueryHandler : IRequestHandler<GetEtapasEnsinoByLocalidadeIdQuery, EtapaEnsinoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEtapasEnsinoByLocalidadeIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EtapaEnsinoDto> Handle(GetEtapasEnsinoByLocalidadeIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Series
            .Where(x => x.Localidade.Id == request.LocalidadeId)
            .Select(s => s.EtapaEnsino).Distinct()
            .AsNoTracking()
            .ProjectTo<EtapaEnsinoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
