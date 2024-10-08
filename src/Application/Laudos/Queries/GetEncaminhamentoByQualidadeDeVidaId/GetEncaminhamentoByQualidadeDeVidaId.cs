using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Encaminhamentos.Queries;

namespace DnaBrasilApi.Application.Laudos.Queries.GetEncaminhamentoByQualidadeDeVidaId;

public record GetEncaminhamentoByQualidadeDeVidaIdQuery(int Id) : IRequest<List<EncaminhamentoDto>>;

public class GetEncaminhamentoByQualidadeDeVidaIdQueryHandler : IRequestHandler<GetEncaminhamentoByQualidadeDeVidaIdQuery, List<EncaminhamentoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEncaminhamentoByQualidadeDeVidaIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EncaminhamentoDto>> Handle(GetEncaminhamentoByQualidadeDeVidaIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.QualidadeDeVidas
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<QualidadeDeVidaDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (result == null)
        {
            Guard.Against.NotFound(request.Id, result);
        }

        var listEncaminhamento = new List<EncaminhamentoDto>();

        if (result.Encaminhamentos != null)
        {
            foreach (var item in result.Encaminhamentos.Split(',').ToList())
            {
                var encaminhamento = await _context.Encaminhamentos
                    .Where(x => x.Id == Convert.ToInt32(item))
                    .AsNoTracking()
                    .ProjectTo<EncaminhamentoDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken);

                if (encaminhamento != null)
                {
                    listEncaminhamento.Add(encaminhamento);
                }
                else
                {
                    Guard.Against.NotFound(Convert.ToInt32(item), encaminhamento);
                }
            }
        }
        else
        {
            Guard.Against.NotFound(request.Id, result.Encaminhamentos);
        }

        return listEncaminhamento! == null ? throw new ArgumentNullException(nameof(listEncaminhamento)) : listEncaminhamento;
    }
}
