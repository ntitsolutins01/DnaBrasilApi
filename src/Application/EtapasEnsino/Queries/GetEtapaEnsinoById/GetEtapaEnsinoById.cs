using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.EtapasEnsino.Queries.GetEtapaEnsinoById;

public record GetEtapaEnsinoByIdQuery : IRequest<EtapaEnsinoDto>
{
    public required int Id { get; init; }
}

public class GetEtapaEnsinoByIdQueryHandler : IRequestHandler<GetEtapaEnsinoByIdQuery, EtapaEnsinoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEtapaEnsinoByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EtapaEnsinoDto> Handle(GetEtapaEnsinoByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.EtapasEnsino
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<EtapaEnsinoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
