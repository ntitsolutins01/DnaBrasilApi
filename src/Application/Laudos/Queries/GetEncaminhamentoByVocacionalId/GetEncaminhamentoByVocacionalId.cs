using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Encaminhamentos.Queries;

namespace DnaBrasilApi.Application.Laudos.Queries.GetEncaminhamentoByVocacionalId;

public record GetEncaminhamentoByVocacionalIdQuery : IRequest<List<EncaminhamentoDto>>;

public class GetEncaminhamentoByVocacionalIdQueryHandler : IRequestHandler<GetEncaminhamentoByVocacionalIdQuery, List<EncaminhamentoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEncaminhamentoByVocacionalIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EncaminhamentoDto>> Handle(GetEncaminhamentoByVocacionalIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Encaminhamentos
            .Where(x => x.TipoLaudo.Id == 6)
            .AsNoTracking()
            .ProjectTo<EncaminhamentoDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
