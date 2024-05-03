using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetTotalizadorEtniaAlunos;
//[Authorize]
public record GetTotalizadorEtniaAlunosQuery : IRequest<TotalizadorEtniaDto>
{
    public DashboardDto? SearchFilter { get; init; }

}

public class GetTotalizadorEtniaAlunosQueryHandler : IRequestHandler<GetTotalizadorEtniaAlunosQuery, TotalizadorEtniaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTotalizadorEtniaAlunosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<TotalizadorEtniaDto> Handle(GetTotalizadorEtniaAlunosQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Aluno> alunos;

        alunos = _context.Alunos
            .AsNoTracking();

        var result = FilterAlunosPeriodo(alunos, request.SearchFilter!, cancellationToken);

        return Task.FromResult(result);
    }

    private TotalizadorEtniaDto FilterAlunosPeriodo(IQueryable<Aluno> alunos, DashboardDto search, CancellationToken cancellationToken)
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

        Dictionary<string, decimal> dict = new()
        {
            { "PARDO", 0 }, { "BRANCO", 0 }, { "PRETO", 0 }, { "INDIGENA", 0 },{ "AMARELO", 0 }
        };
        Dictionary<string, decimal> dictTotalizadorEtniaMasculino = new()
        {
            { "PARDO", 0 }, { "BRANCO", 0 }, { "PRETO", 0 }, { "INDIGENA", 0 },{ "AMARELO", 0 }
        };
        Dictionary<string, decimal> dictTotalizadorEtniaFeminino = new()
        {
            { "PARDO", 0 }, { "BRANCO", 0 }, { "PRETO", 0 }, { "INDIGENA", 0 },{ "AMARELO", 0 }
        };

        foreach (Aluno aluno in alunos)
        {
            var value = dict[aluno.Etnia!];

            value += 1;

            dict[aluno.Etnia!] = value;

            switch (aluno.Etnia)
            {
                case "PARDO":
                    if (aluno.Sexo.Equals("M"))
                    {
                        var pardoMasc = dictTotalizadorEtniaMasculino["PARDO"];
                        pardoMasc += 1;
                        dictTotalizadorEtniaMasculino["PARDO"] = pardoMasc;
                    }
                    else
                    {
                        var pardoFem = dictTotalizadorEtniaFeminino["PARDO"];
                        pardoFem += 1;
                        dictTotalizadorEtniaFeminino["PARDO"] = pardoFem;
                    }

                    break;
                case "BRANCO":
                    if (aluno.Sexo.Equals("M"))
                    {
                        var brancoMasc = dictTotalizadorEtniaMasculino["BRANCO"];
                        brancoMasc += 1;
                        dictTotalizadorEtniaMasculino["BRANCO"] = brancoMasc;
                    }
                    else
                    {
                        var brancoFem = dictTotalizadorEtniaFeminino["BRANCO"];
                        brancoFem += 1;
                        dictTotalizadorEtniaFeminino["BRANCO"] = brancoFem;
                    }
                    break;
                case "PRETO":
                    if (aluno.Sexo.Equals("M"))
                    {
                        var pretoMasc = dictTotalizadorEtniaMasculino["PRETO"];
                        pretoMasc += 1;
                        dictTotalizadorEtniaMasculino["PRETO"] = pretoMasc;
                    }
                    else
                    {
                        var pretoFem = dictTotalizadorEtniaFeminino["PRETO"];
                        pretoFem += 1;
                        dictTotalizadorEtniaFeminino["PRETO"] = pretoFem;
                    }
                    break;
                case "INDIGENA":
                    if (aluno.Sexo.Equals("M"))
                    {
                        var indigenaMasc = dictTotalizadorEtniaMasculino["INDIGENA"];
                        indigenaMasc += 1;
                        dictTotalizadorEtniaMasculino["INDIGENA"] = indigenaMasc;
                    }
                    else
                    {
                        var indigenaFem = dictTotalizadorEtniaFeminino["INDIGENA"];
                        indigenaFem += 1;
                        dictTotalizadorEtniaFeminino["INDIGENA"] = indigenaFem;
                    }
                    break;
                case "AMARELO":
                    if (aluno.Sexo.Equals("M"))
                    {
                        var amareloMasc = dictTotalizadorEtniaMasculino["AMARELO"];
                        amareloMasc += 1;
                        dictTotalizadorEtniaMasculino["AMARELO"] = amareloMasc;
                    }
                    else
                    {
                        var amareloFem = dictTotalizadorEtniaFeminino["AMARELO"];
                        amareloFem += 1;
                        dictTotalizadorEtniaFeminino["AMARELO"] = amareloFem;
                    }
                    break;
            }
        }

        var totalMasc = dictTotalizadorEtniaMasculino.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percTotalizadorEtniaMasculino = dictTotalizadorEtniaMasculino.Where(item => totalMasc != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / totalMasc).ToString("F")));

        var totalFem = dictTotalizadorEtniaFeminino.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percTotalizadorEtniaFeminino = dictTotalizadorEtniaFeminino.Where(item => totalFem != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / totalFem).ToString("F")));

        var total = dict.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percEtnia = dict.Where(item => total != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / total).ToString("F")));

        return new TotalizadorEtniaDto
        {
            ValorTotalizadorEtniaMasculino = dictTotalizadorEtniaMasculino,
            ValorTotalizadorEtniaFeminino = dictTotalizadorEtniaFeminino,
            PercTotalizadorEtniaMasculino = percTotalizadorEtniaMasculino,
            PercTotalizadorEtniaFeminino = percTotalizadorEtniaFeminino,
            PercEtnia = percEtnia
        };
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

            return (YearsOld < 0) ? 0 : YearsOld;
        }
        catch
        {
            return 0;
        }
    }
}

