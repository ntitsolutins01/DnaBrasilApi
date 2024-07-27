using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TiposParcerias.Queries.GetTipoParceriaById;

public record GetTipoParceriaByIdQuery : IRequest<TipoParceriaDto>
{
    public required int Id { get; init; }
}

public class GetTipoParceriaByIdQueryHandler : IRequestHandler<GetTipoParceriaByIdQuery, TipoParceriaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTipoParceriaByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TipoParceriaDto> Handle(GetTipoParceriaByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.TiposParcerias
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<TipoParceriaDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
