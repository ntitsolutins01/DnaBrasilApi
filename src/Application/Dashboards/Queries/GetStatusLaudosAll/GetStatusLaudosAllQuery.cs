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
                _context.Laudos.Include(i=>i.TalentoEsportivo).Count(c => c.TalentoEsportivo != null),
            TotTalentoEsportivoAndamento =
                _context.Laudos.Include(i => i.TalentoEsportivo).Count(c => c.TalentoEsportivo == null),

            TotSaudeFinalizado = _context.Laudos.Include(i=>i.Saude).Count(c => c.Saude != null),
            TotSaudeAndamento = _context.Laudos.Include(i=>i.Saude).Count(c => c.Saude == null),

            TotConsumoAlimentarFinalizado = _context.Laudos.Include(i=>i.Consumo).Count(c => c.Consumo != null),
            TotConsumoAlimentarAndamento = _context.Laudos.Include(i=>i.Consumo).Count(c => c.Consumo == null),


            TotQualidadeDeVidaFinalizado =_context.Laudos.Include(i => i.QualidadeDeVida).Count(c => c.QualidadeDeVida != null),
            TotQualidadeDeVidaAndamento =_context.Laudos.Include(i => i.QualidadeDeVida).Count(c => c.QualidadeDeVida == null),


            TotVocacionalFinalizado = _context.Laudos.Include(i => i.Vocacional).Count(c => c.Vocacional != null),
            TotVocacionalAndamento = _context.Laudos.Include(i => i.Vocacional).Count(c => c.Vocacional == null),

            TotSaudeBucalFinalizado = _context.Laudos.Include(i => i.SaudeBucal).Count(c => c.SaudeBucal != null),
            TotSaudeBucalAndamento = _context.Laudos.Include(i => i.SaudeBucal).Count(c => c.SaudeBucal == null),
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

