using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Cursos.Queries;
using DnaBrasilApi.Application.Encaminhamentos.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Queries.GetEncaminhamentoBySaudeId;

public record GetEncaminhamentoBySaudeIdQuery(int SaudeId) : IRequest<EncaminhamentoDto>;

public class GetEncaminhamentoBySaudeIdQueryHandler : IRequestHandler<GetEncaminhamentoBySaudeIdQuery, EncaminhamentoDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEncaminhamentoBySaudeIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EncaminhamentoDto?> Handle(GetEncaminhamentoBySaudeIdQuery request, CancellationToken cancellationToken)
    {

        var saude = await _context.Saudes
            .Where(x => x.Id == request.SaudeId)
            .AsNoTracking()
            .ProjectTo<SaudeDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        double alturaMetros = (double)(saude!.Altura * (decimal?)0.01)!;
        var imc = Convert.ToDecimal(((double)saude.Massa! / Math.Pow(alturaMetros, 2)).ToString("F"));
        var idade = GetIdade(saude.DtNascimento, DateTime.Now);

        var metricasImc = _context.MetricasImc
            .Where(x => x.Idade == idade && x.Sexo == (idade == 99 ? "G" : saude.Sexo)).ToList();

        var resultMetrrica = metricasImc.Find(
            delegate (MetricaImc item)
            {
                return imc >= item.ValorInicial && imc <= item.ValorFinal;
            }
        );

        var encaminhamento = await _context.Encaminhamentos
            .Where(x=>resultMetrrica != null && x.Parametro.Equals(resultMetrrica.Classificacao))
            .AsNoTracking()
            .ProjectTo<EncaminhamentoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return encaminhamento;
    }
    /// <summary>
    /// Calcula quantidade de anos passdos com base em duas datas, caso encontre qualquer problema retorna 0 
    /// </summary>
    /// <param name="data">Data inicial</param>
    /// <param name="now">Data final ou deixar nula para data atual</param>
    /// <returns>Retorna inteiro com quantiadde de anos</returns>
    private static int GetIdade(DateTime data, DateTime? now = null)
    {
        // Carrega a data do dia para comparação caso data informada seja nula

        now = ((now == null) ? DateTime.Now : now);

        try
        {
            int YearsOld = (now.Value.Year - data.Year);

            if (now.Value.Month < data.Month || (now.Value.Month == data.Month && now.Value.Day < data.Day))
            {
                YearsOld--;
            }

            return YearsOld > 18 ? 99 : YearsOld < 4 ? 4 : YearsOld;
        }
        catch
        {
            return 0;
        }
    }
}
