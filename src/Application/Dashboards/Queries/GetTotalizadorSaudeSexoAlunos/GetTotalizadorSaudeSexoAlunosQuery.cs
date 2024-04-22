using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetTotalizadorSaudeSexoAlunos;
//[Authorize]
public record GetTotalizadorSaudeSexoAlunosQuery : IRequest<TotalizadorSexoSaudeDto>
{
    public DashboardDto? SearchFilter { get; init; }

}

public class GetTotalizadorSaudeSexoAlunosQueryHandler : IRequestHandler<GetTotalizadorSaudeSexoAlunosQuery, TotalizadorSexoSaudeDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTotalizadorSaudeSexoAlunosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<TotalizadorSexoSaudeDto> Handle(GetTotalizadorSaudeSexoAlunosQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Aluno> alunos;

        alunos = _context.Alunos
            .AsNoTracking();

        var result = FilterAlunosPeriodo(alunos, request.SearchFilter!, cancellationToken);

        return Task.FromResult(result);
    }

    private TotalizadorSexoSaudeDto FilterAlunosPeriodo(IQueryable<Aluno> alunos, DashboardDto search, CancellationToken cancellationToken)
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

        var metricasImc = _context.MetricasImc
            .Where(x => x.Sexo!.Equals("G"));

        var verificaAlunos = alunos.Select(x => x.Id);

        Dictionary<string, decimal> dict = new();
        Dictionary<string, decimal> dictTotalizadorSaudeMasculino = new()
        {
            { "baixoPeso", 0 }, { "acimaPeso", 0 }, { "riscoColesterolAlto", 0 }, { "riscoHipertensao", 0 },
            { "resistenciaInsulina", 0 },
            { "desequilibrioMuscular", 0 },
            { "indicePositivoSaude", 0 }
        };
        Dictionary<string, decimal> dictTotalizadorSaudeFeminino = new()
        {
            { "baixoPeso", 0 }, { "acimaPeso", 0 }, { "riscoColesterolAlto", 0 }, { "riscoHipertensao", 0 },
            { "resistenciaInsulina", 0 },
            { "desequilibrioMuscular", 0 },
            { "indicePositivoSaude", 0 }
        };
        int cont = 1;

        var laudos = _context.Laudos.Where(x => verificaAlunos.Contains(x.Aluno.Id)).Include(i => i.Saude).AsNoTracking()
            .ProjectTo<LaudoDto>(_mapper.ConfigurationProvider);

        foreach (var aluno in laudos)
        {
            if (aluno.Saude != null)
            {
                double alturaMetros = (double)(aluno.Saude.Altura * 0.01)!;
                if (alturaMetros == 0)
                {
                    continue;
                }

                double? imc = (double)aluno.Saude!.Massa! / Math.Pow(alturaMetros, 2);

                foreach (var item in metricasImc)
                {
                    if (!dict.ContainsKey(item.Classificacao!))
                    {
                        dict.Add(item.Classificacao!, 0);
                    }

                    if (imc >= (double)item.ValorInicial && imc <= (double)item.ValorFinal)
                    {
                        if (dict.ContainsKey(item.Classificacao!))
                        {
                            var value = dict[item.Classificacao!];

                            value += 1;

                            dict[item.Classificacao!] = value;

                            switch (item.Classificacao!)
                            {
                                case "NORMAL":
                                    if (aluno.Equals("M"))
                                    {
                                        var indicePositivoSaudeMasc =
                                            dictTotalizadorSaudeMasculino["indicePositivoSaude"];
                                        indicePositivoSaudeMasc += 1;
                                        dictTotalizadorSaudeMasculino["indicePositivoSaude"] =
                                            indicePositivoSaudeMasc;
                                    }
                                    else
                                    {
                                        var indicePositivoSaudeFem =
                                            dictTotalizadorSaudeFeminino["indicePositivoSaude"];
                                        indicePositivoSaudeFem =
                                            dictTotalizadorSaudeFeminino["indicePositivoSaude"];
                                        dictTotalizadorSaudeFeminino["indicePositivoSaude"] =
                                            indicePositivoSaudeFem;
                                    }

                                    break;
                                case "ABAIXODONORMAL":
                                    if (aluno.Equals("M"))
                                    {
                                        var desequilibrioMuscularMasc =
                                            dictTotalizadorSaudeMasculino["desequilibrioMuscular"];
                                        desequilibrioMuscularMasc += 1;
                                        dictTotalizadorSaudeMasculino["desequilibrioMuscular"] =
                                            desequilibrioMuscularMasc;
                                    }
                                    else
                                    {
                                        var desequilibrioMuscularFem =
                                            dictTotalizadorSaudeFeminino["desequilibrioMuscular"];
                                        desequilibrioMuscularFem += 1;
                                        dictTotalizadorSaudeFeminino["desequilibrioMuscular"] =
                                            desequilibrioMuscularFem;
                                    }

                                    break;
                                case "SOBREPESO":
                                    if (aluno.Equals("M"))
                                    {
                                        var resistenciaInsulinaMasc =
                                            dictTotalizadorSaudeMasculino["resistenciaInsulina"];
                                        resistenciaInsulinaMasc += 1;
                                        dictTotalizadorSaudeMasculino["resistenciaInsulina"] =
                                            resistenciaInsulinaMasc;
                                    }
                                    else
                                    {
                                        var resistenciaInsulinaFem =
                                            dictTotalizadorSaudeFeminino["resistenciaInsulinaMasc"];
                                        resistenciaInsulinaFem += 1;
                                        dictTotalizadorSaudeFeminino["resistenciaInsulinaMasc"] =
                                            resistenciaInsulinaFem;
                                    }

                                    break;
                                case "OBESIDADE":
                                    if (aluno.Equals("M"))
                                    {
                                        var riscoColesterolAltoMasc =
                                            dictTotalizadorSaudeMasculino["riscoColesterolAlto"];
                                        riscoColesterolAltoMasc += 1;
                                        dictTotalizadorSaudeMasculino["riscoColesterolAlto"] =
                                            riscoColesterolAltoMasc;

                                        var riscoHipertensaoMasc =
                                            dictTotalizadorSaudeMasculino["riscoHipertensao"];
                                        riscoHipertensaoMasc += 1;
                                        dictTotalizadorSaudeMasculino["riscoHipertensao"] = riscoHipertensaoMasc;

                                        var resistenciaInsulinaMasc =
                                            dictTotalizadorSaudeMasculino["resistenciaInsulina"];
                                        resistenciaInsulinaMasc += 1;
                                        dictTotalizadorSaudeMasculino["resistenciaInsulina"] =
                                            resistenciaInsulinaMasc;
                                    }
                                    else
                                    {
                                        var riscoColesterolAltoFem =
                                            dictTotalizadorSaudeFeminino["riscoColesterolAlto"];
                                        riscoColesterolAltoFem += 1;
                                        dictTotalizadorSaudeFeminino["riscoColesterolAlto"] =
                                            riscoColesterolAltoFem;

                                        var riscoHipertensaoFem = dictTotalizadorSaudeFeminino["riscoHipertensao"];
                                        riscoHipertensaoFem += 1;
                                        dictTotalizadorSaudeFeminino["riscoHipertensao"] = riscoHipertensaoFem;

                                        var resistenciaInsulinaFem =
                                            dictTotalizadorSaudeFeminino["resistenciaInsulina"];
                                        resistenciaInsulinaFem += 1;
                                        dictTotalizadorSaudeFeminino["resistenciaInsulina"] =
                                            resistenciaInsulinaFem;
                                    }

                                    break;
                            }
                        }
                        else
                        {
                            dict.Add(item.Classificacao!, cont);
                        }
                    }
                }
            }
        }

        var valorTotalizadorSaudeMasculino = dictTotalizadorSaudeMasculino;

        var valorTotalizadorSaudeFeminino = dictTotalizadorSaudeFeminino;

        var totalMasc = dictTotalizadorSaudeMasculino.Skip(0).Sum(x => x.Value);


        Dictionary<string, decimal> percTotalizadorSaudeMasculino = dictTotalizadorSaudeMasculino.Where(item => totalMasc != 0).ToDictionary(item => item.Key!, item => 100 * item.Value / totalMasc);

        var totalFem = dictTotalizadorSaudeFeminino.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percTotalizadorSaudeFeminino = dictTotalizadorSaudeFeminino.Where(item => totalFem != 0).ToDictionary(item => item.Key!, item => 100 * item.Value / totalFem);


        return new TotalizadorSexoSaudeDto
        {
            ValorTotalizadorSaudeMasculino = valorTotalizadorSaudeMasculino,
            ValorTotalizadorSaudeFeminino = valorTotalizadorSaudeFeminino,
            PercTotalizadorSaudeMasculino = percTotalizadorSaudeMasculino,
            PercTotalizadorSaudeFeminino = percTotalizadorSaudeFeminino
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

