using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetPercentualSaudeAlunos;
//[Authorize]
public record GetPercentualSaudeAlunosQuery : IRequest<Dictionary<string, decimal>>
{
    public DashboardDto? SearchFilter { get; init; }

}

public class GetPercentualSaudeAlunosQueryHandler : IRequestHandler<GetPercentualSaudeAlunosQuery, Dictionary<string, decimal>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPercentualSaudeAlunosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<Dictionary<string, decimal>> Handle(GetPercentualSaudeAlunosQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Aluno> alunos;

        alunos = _context.Alunos
            .AsNoTracking();

        var result = FilterAlunosPeriodo(alunos, request.SearchFilter!, cancellationToken);

        return Task.FromResult(result);
    }

    private Dictionary<string, decimal> FilterAlunosPeriodo(IQueryable<Aluno> alunos, DashboardDto search, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.FomentoId))
        {
            var id = Convert.ToInt32(search.FomentoId.Split("-")[0]);

            alunos = alunos.Where(u => u.Fomento!.Id == id);
        }

        if (!string.IsNullOrWhiteSpace(search.Estado))
        {
            alunos = alunos.Where(u => u.Municipio!.Estado!.Sigla!.Contains(search.Estado));
        }

        if (!string.IsNullOrWhiteSpace(search.MunicipioId))
        {
            alunos = alunos.Where(u => u.Municipio!.Id == Convert.ToInt32(search.MunicipioId));
        }

        if (!string.IsNullOrWhiteSpace(search.LocalidadeId))
        {
            alunos = alunos.Where(u => u.Localidade!.Id == Convert.ToInt32(search.LocalidadeId));
        }

        if (!string.IsNullOrWhiteSpace(search.DeficienciaId))
        {
            var deficiencias = _context.Deficiencias
                .Include(i => i.Alunos)
                .First(f => f.Id == Convert.ToInt32(search.DeficienciaId));

            var listAlunos = deficiencias.Alunos!.Select(s => s.Id).ToList();

            alunos = alunos.Where(u => listAlunos.Contains(u.Id));
        }

        if (!string.IsNullOrWhiteSpace(search.Etnia))
        {
            alunos = alunos.Where(u => u.Etnia!.Equals(search.Etnia));
        }

        var verificaAlunos = alunos.Select(x => x.Id);

        Dictionary<string, decimal> dict = new();

        int cont = 1;

        var laudos = _context.Laudos.Where(x => verificaAlunos.Contains(x.Aluno.Id)).Include(i => i.Saude).Include(a=>a.Aluno)
            .AsNoTracking();

        foreach (var aluno in laudos)
        {
            if (aluno.Saude == null)
            {
                continue;
            }

            double alturaMetros = (double)(aluno.Saude.Altura * (decimal?)0.01)!;
            var imc = Convert.ToDecimal(((double)aluno.Saude!.Massa! / Math.Pow(alturaMetros, 2)).ToString("F"));
            var idade = GetIdade(aluno.Aluno!.DtNascimento, DateTime.Now);

            var metricasImc = _context.MetricasImc
                .Where(x => x.Idade == idade && x.Sexo == (idade == 99 ? "G" : aluno.Aluno.Sexo)).ToList();

            var result = metricasImc.Find(
                delegate (MetricaImc item)
                {
                    return imc >= item.ValorInicial && imc <= item.ValorFinal;
                }
            );
            if (result != null && !dict.ContainsKey(result.Classificacao!))
            {
                dict.Add(result.Classificacao!, 0);
            }
            if (result != null && dict.ContainsKey(result.Classificacao!))
            {
                var value = dict[result.Classificacao!];

                value += 1;

                dict[result.Classificacao!] = value;
            }
            else
            {
                dict.Add(result!.Classificacao!, cont);
            }

            //foreach (var item in metricasImc)
            //{
            //    if (!dict.ContainsKey(item.Classificacao!))
            //    {
            //        dict.Add(item.Classificacao!, 0);
            //    }

            //    if (imc >= (double)item.ValorInicial && imc <= (double)item.ValorFinal)
            //    {
            //        if (dict.ContainsKey(item.Classificacao!))
            //        {
            //            var value = dict[item.Classificacao!];

            //            value += 1;

            //            dict[item.Classificacao!] = value;
            //        }
            //        else
            //        {
            //            dict.Add(item.Classificacao!, cont);
            //        }
            //    }
            //}
        }

        var total = dict.Skip(0).Sum(x => x.Value);

        foreach (KeyValuePair<string, decimal> item in dict)
        {
            dict[item.Key!] = Convert.ToDecimal((100 * item.Value / total).ToString("F"));
        }

        return dict;
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

