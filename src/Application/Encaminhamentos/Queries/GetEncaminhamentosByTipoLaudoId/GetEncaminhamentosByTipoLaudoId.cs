using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Encaminhamentos.Queries.GetEncaminhamentosByTipoLaudoId;

public record GetEncaminhamentosByTipoLaudoIdQuery : IRequest<List<EncaminhamentoDto>>
{
    public required int Id { get; init; }
}

public class GetEncaminhamentosByTipoLaudoIdQueryHandler : IRequestHandler<GetEncaminhamentosByTipoLaudoIdQuery, List<EncaminhamentoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEncaminhamentosByTipoLaudoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EncaminhamentoDto>> Handle(GetEncaminhamentosByTipoLaudoIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Encaminhamentos
            .Where(x => x.TipoLaudo.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<EncaminhamentoDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
