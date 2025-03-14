using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Encaminhamentos.Queries;

namespace DnaBrasilApi.Application.Laudos.Queries.GetEncaminhamentoByConsumoAlimentarId;

public record GetEncaminhamentoByConsumoAlimentarIdQuery(int Id) : IRequest<EncaminhamentoDto>;

public class GetEncaminhamentoByConsumoAlimentarIdQueryHandler : IRequestHandler<GetEncaminhamentoByConsumoAlimentarIdQuery, EncaminhamentoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEncaminhamentoByConsumoAlimentarIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EncaminhamentoDto> Handle(GetEncaminhamentoByConsumoAlimentarIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ConsumoAlimentares
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<ConsumoAlimentarDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result?.Encaminhamento == null ? throw new ArgumentNullException(nameof(result.Encaminhamento)) : result.Encaminhamento;
    }
}
