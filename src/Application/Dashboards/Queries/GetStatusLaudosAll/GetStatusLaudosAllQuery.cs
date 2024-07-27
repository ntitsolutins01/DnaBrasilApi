using System.Linq;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetStatusLaudosAll;
//[Authorize]
public record GetStatusLaudosAllQuery : IRequest<StatusLaudosDto>
{
    public DashboardDto? SearchFilter { get; init; }
};

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
        IQueryable<Laudo> laudos;

        laudos = _context.Laudos
            .Include(i=>i.Aluno)
            .AsNoTracking();

        var result = FilterLaudos(laudos, request.SearchFilter!, cancellationToken);

        var statusLaudos = new StatusLaudosDto()
        {
            TotTalentoEsportivoFinalizado =
                result.Include(i=>i.TalentoEsportivo).Count(c => c.TalentoEsportivo != null),
            TotTalentoEsportivoAndamento =
                result.Include(i => i.TalentoEsportivo).Count(c => c.TalentoEsportivo == null),

            TotSaudeFinalizado = result.Include(i=>i.Saude).Count(c => c.Saude != null),
            TotSaudeAndamento = result.Include(i=>i.Saude).Count(c => c.Saude == null),

            TotConsumoAlimentarFinalizado = result.Include(i=>i.Consumo).Count(c => c.Consumo != null),
            TotConsumoAlimentarAndamento = result.Include(i=>i.Consumo).Count(c => c.Consumo == null),


            TotQualidadeDeVidaFinalizado =result.Include(i => i.QualidadeDeVida).Count(c => c.QualidadeDeVida != null),
            TotQualidadeDeVidaAndamento =result.Include(i => i.QualidadeDeVida).Count(c => c.QualidadeDeVida == null),


            TotVocacionalFinalizado = result.Include(i => i.Vocacional).Count(c => c.Vocacional != null),
            TotVocacionalAndamento = result.Include(i => i.Vocacional).Count(c => c.Vocacional == null),

            TotSaudeBucalFinalizado = result.Include(i => i.SaudeBucal).Count(c => c.SaudeBucal != null),
            TotSaudeBucalAndamento = result.Include(i => i.SaudeBucal).Count(c => c.SaudeBucal == null),
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

    private IQueryable<Laudo> FilterLaudos(IQueryable<Laudo> laudos, DashboardDto search,
        CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.FomentoId))
        {
            var id = Convert.ToInt32(search.FomentoId.Split("-")[0]);

            laudos = laudos.Where(u => u.Aluno.Fomento.Id == id);
        }

        if (!string.IsNullOrWhiteSpace(search.Estado))
        {
            laudos = laudos.Where(u => u.Aluno.Municipio!.Estado!.Sigla!.Contains(search.Estado));
        }

        if (!string.IsNullOrWhiteSpace(search.MunicipioId))
        {
            laudos = laudos.Where(u => u.Aluno.Municipio!.Id == Convert.ToInt32(search.MunicipioId));
        }

        if (!string.IsNullOrWhiteSpace(search.LocalidadeId))
        {
            laudos = laudos.Where(u => u.Aluno.Localidade!.Id == Convert.ToInt32(search.LocalidadeId));
        }

        if (!string.IsNullOrWhiteSpace(search.DeficienciaId))
        {
            var deficiencias = _context.Deficiencias
                .Include(i => i.Alunos)
                .First(f => f.Id == Convert.ToInt32(search.DeficienciaId));

            var listAlunos = deficiencias.Alunos!.Select(s => s.Id).ToList();

            laudos = laudos.Where(u => listAlunos.Contains(u.Id));
        }

        if (!string.IsNullOrWhiteSpace(search.Etnia))
        {
            laudos = laudos.Where(u => u.Aluno.Etnia!.Equals(search.Etnia));
        }

        return laudos;
    }
}

