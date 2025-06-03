using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Encaminhamentos.Queries;

namespace DnaBrasilApi.Application.Laudos.Queries.GetEncaminhamentoBySaudeBucalId;

public record GetEncaminhamentoBySaudeBucalIdQuery(int Id) : IRequest<EncaminhamentoDto>;

public class GetEncaminhamentoBySaudeBucalIdQueryHandler : IRequestHandler<GetEncaminhamentoBySaudeBucalIdQuery, EncaminhamentoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEncaminhamentoBySaudeBucalIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EncaminhamentoDto> Handle(GetEncaminhamentoBySaudeBucalIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.SaudeBucais
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<SaudeBucalDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result?.Encaminhamento == null ? throw new ArgumentNullException(nameof(result.Encaminhamento)) : result.Encaminhamento;
    }
}
