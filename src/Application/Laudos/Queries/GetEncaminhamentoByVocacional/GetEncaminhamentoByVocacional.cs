using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Encaminhamentos.Queries;

namespace DnaBrasilApi.Application.Laudos.Queries.GetEncaminhamentoByVocacional;

public record GetEncaminhamentoByVocacionalQuery : IRequest<List<EncaminhamentoDto>>;

public class GetEncaminhamentoByVocacionalQueryHandler : IRequestHandler<GetEncaminhamentoByVocacionalQuery, List<EncaminhamentoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEncaminhamentoByVocacionalQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EncaminhamentoDto>> Handle(GetEncaminhamentoByVocacionalQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Encaminhamentos
            .Where(x => x.TipoLaudo.Id == 6)
            .AsNoTracking()
            .ProjectTo<EncaminhamentoDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
