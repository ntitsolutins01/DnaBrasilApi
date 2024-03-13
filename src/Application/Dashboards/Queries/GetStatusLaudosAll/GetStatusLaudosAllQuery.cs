using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetStatusLaudosAll;
//[Authorize]
public record GetStatusLaudosAllQuery : IRequest<StatusLaudosDto>;

public class GetStatusLaudosAllQueryHandler : IRequestHandler<GetStatusLaudosAllQuery, StatusLaudosDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetStatusLaudosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public  Task<StatusLaudosDto> Handle(GetStatusLaudosAllQuery request, CancellationToken cancellationToken)
    {
        var statusLaudos = new StatusLaudosDto()
        {
            TotTalentoEsportivoFinalizado =
                _context.TalentosEsportivos.Count(c => c.StatusTalentosEsportivos!.Equals("F")),
            TotTalentoEsportivoAndamento =
                _context.TalentosEsportivos.Count(c => c.StatusTalentosEsportivos!.Equals("A")),
            TotSaudeFinalizado = _context.Saudes.Count(c => c.StatusSaude!.Equals("F")),
            TotSaudeAndamento = _context.Saudes.Count(c => c.StatusSaude!.Equals("A")),
            TotQualidadeDeVidaFinalizado =
                _context.QualidadeDeVidas.Count(c => c.StatusQualidadeDeVidas!.Equals("F")),
            TotQualidadeDeVidaAndamento =
                _context.QualidadeDeVidas.Count(c => c.StatusQualidadeDeVidas!.Equals("A")),
            TotVocacionalFinalizado = _context.Vocacionais.Count(c => c.StatusVocacionais!.Equals("F")),
            TotVocacionalAndamento = _context.Vocacionais.Count(c => c.StatusVocacionais!.Equals("A")),
            TotConsumoAlimentarFinalizado =
                _context.ConsumoAlimentares.Count(c => c.StatusConsumoAlimentares!.Equals("F")),
            TotConsumoAlimentarAndamento =
                _context.ConsumoAlimentares.Count(c => c.StatusConsumoAlimentares!.Equals("A")),
            TotSaudeBucalFinalizado = _context.SaudeBucais.Count(c => c.StatusSaudeBucais!.Equals("F")),
            TotSaudeBucalAndamento = _context.SaudeBucais.Count(c => c.StatusSaudeBucais!.Equals("A")),
        };

        statusLaudos.ProgressoSaude =
            statusLaudos.TotSaudeAndamento + statusLaudos.TotSaudeFinalizado == 0
                ? 0
                : statusLaudos.TotSaudeFinalizado * 100 /
                  (statusLaudos.TotSaudeAndamento + statusLaudos.TotSaudeFinalizado);


        statusLaudos.ProgressoTalentoEsportivo = statusLaudos.TotTalentoEsportivoAndamento +
            statusLaudos.TotTalentoEsportivoFinalizado == 0
                ? 0
                : statusLaudos.TotTalentoEsportivoFinalizado * 100 / (statusLaudos.TotTalentoEsportivoAndamento +
                                                                      statusLaudos.TotTalentoEsportivoFinalizado);

        statusLaudos.ProgressoQualidadeDeVida = statusLaudos.TotQualidadeDeVidaAndamento +
            statusLaudos.TotQualidadeDeVidaFinalizado == 0
                ? 0
                : statusLaudos.TotQualidadeDeVidaFinalizado * 100 / (statusLaudos.TotQualidadeDeVidaAndamento +
                                                                     statusLaudos.TotQualidadeDeVidaFinalizado);

        statusLaudos.ProgressoVocacional =
            statusLaudos.TotVocacionalAndamento + statusLaudos.TotVocacionalFinalizado == 0
                ? 0
                : statusLaudos.TotVocacionalFinalizado * 100 /
                  (statusLaudos.TotVocacionalAndamento + statusLaudos.TotVocacionalFinalizado);

        statusLaudos.ProgressoConsumoAlimentar = statusLaudos.TotConsumoAlimentarAndamento +
            statusLaudos.TotConsumoAlimentarFinalizado == 0
                ? 0
                : statusLaudos.TotConsumoAlimentarFinalizado * 100 / (statusLaudos.TotConsumoAlimentarAndamento +
                                                                      statusLaudos.TotConsumoAlimentarFinalizado);

        statusLaudos.ProgressoSaudeBucal =
            statusLaudos.TotSaudeBucalAndamento + statusLaudos.TotSaudeBucalFinalizado == 0
                ? 0
                : statusLaudos.TotSaudeBucalFinalizado * 100 /
                  (statusLaudos.TotSaudeBucalAndamento + statusLaudos.TotSaudeBucalFinalizado);

        return Task.FromResult(statusLaudos);
    }
}

