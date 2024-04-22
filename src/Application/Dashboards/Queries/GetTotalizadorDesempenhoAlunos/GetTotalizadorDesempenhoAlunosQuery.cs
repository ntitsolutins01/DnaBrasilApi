using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetTotalizadorDesempenhoAlunos;
//[Authorize]
public record GetTotalizadorDesempenhoAlunosQuery : IRequest<TotalizadorDesempenhoDto>
{
    public DashboardDto? SearchFilter { get; init; }

}

public class GetTotalizadorDesempenhoAlunosQueryHandler : IRequestHandler<GetTotalizadorDesempenhoAlunosQuery, TotalizadorDesempenhoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTotalizadorDesempenhoAlunosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<TotalizadorDesempenhoDto> Handle(GetTotalizadorDesempenhoAlunosQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Aluno> alunos;

        alunos = _context.Alunos
            .AsNoTracking();

        var result = FilterDesempenhoAlunos(alunos, request.SearchFilter!, cancellationToken);

        return result;
    }

    private async Task<TotalizadorDesempenhoDto> FilterDesempenhoAlunos(IQueryable<Aluno> alunos, DashboardDto search, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.FomentoId))
        {
            var id = Convert.ToInt32(search.FomentoId.Split("-")[0]);

            alunos = alunos.Where(u => u.Municipio!.Id == id);
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

        var desempenhos = await _context.TextosLaudos
            .Where(x => x.Status && x.TipoLaudo!.Id == 4)
            .Select(s => s.Classificacao)
            .Distinct()
            .ToListAsync();

        Dictionary<string, decimal> dict = new()
        {
            { "velocidade", 0 },
            { "flexibilidadeMuscular", 0 },
            { "forcaMembrosSup", 0 },
            { "forcaExplosiva", 0 },
            { "aptidaoCardio", 0 },
            { "agilidade", 0 },
            { "resAbdominal", 0 },
            { "shutlleRun", 0 },
            { "prancha", 0 },
            { "vo2Max", 0 }
        };

        Dictionary<string, decimal> dictTotalizadorDesempenhoMasculino = new()
        {
            { "velocidade", 0 },
            { "flexibilidadeMuscular", 0 },
            { "forcaMembrosSup", 0 },
            { "forcaExplosiva", 0 },
            { "aptidaoCardio", 0 },
            { "agilidade", 0 },
            { "resAbdominal", 0 },
            { "shutlleRun", 0 },
            { "prancha", 0 },
            { "vo2Max", 0 }
        };
        Dictionary<string, decimal> dictTotalizadorDesempenhoFeminino = new()
        {
            { "velocidade", 0 },
            { "flexibilidadeMuscular", 0 },
            { "forcaMembrosSup", 0 },
            { "forcaExplosiva", 0 },
            { "aptidaoCardio", 0 },
            { "agilidade", 0 },
            { "resAbdominal", 0 },
            { "shutlleRun", 0 },
            { "prancha", 0 },
            { "vo2Max", 0 }
        };

        List<TextoLaudo> textoLaudo = new();
        bool veloVerificaAluno;
        bool impulsaoVerificaAluno;
        bool agilidadeVerificaAluno;
        bool shutlleRunVerificaAluno;
        bool flexibilidadeMuscularVerificaAluno;
        bool forcaMembrosSupVerificaAluno;
        bool aptidaoCardioVerificaAluno;
        bool resAbdominalVerificaAluno;
        bool pranchaVerificaAluno;
        bool vo2MaxVerificaAluno;

        var verificaAlunos = alunos.Select(x => x.Id);

        var laudos = _context.Laudos.Where(x => verificaAlunos.Contains(x.Aluno.Id)).Include(i => i.TalentoEsportivo)
            .AsNoTracking()
            .ProjectTo<LaudoDto>(_mapper.ConfigurationProvider);

        foreach (var aluno in laudos)
        {
            if (aluno.TalentoEsportivo == null)
            {
                continue;
            }

            var idade = GetIdade(aluno.DtNascimento, DateTime.Now);
            veloVerificaAluno = false;
            impulsaoVerificaAluno = false;
            agilidadeVerificaAluno = false;
            shutlleRunVerificaAluno = false;
            flexibilidadeMuscularVerificaAluno = false;
            forcaMembrosSupVerificaAluno = false;
            aptidaoCardioVerificaAluno = false;
            resAbdominalVerificaAluno = false;
            pranchaVerificaAluno = false;
            vo2MaxVerificaAluno = false;


            foreach (var desempenho in desempenhos)
            {
                textoLaudo = _context.TextosLaudos.Where(x =>
                    x.Status &&
                    x.Classificacao!.Equals(desempenho) &&
                    x.Idade == idade &&
                    (x.Aviso!.Trim() == "Excelente" || x.Aviso!.Trim() == "Muito Bom" || x.Aviso!.Trim() == "Bom") &&
                    x.Sexo == aluno.Sexo).ToList();

                foreach (var item in textoLaudo!)
                {
                    if (!veloVerificaAluno)
                    {
                        if (aluno.TalentoEsportivo!.Velocidade >= item.PontoInicial && aluno.TalentoEsportivo!.Velocidade <= item.PontoFinal)
                        {
                            if (aluno.Sexo!.Equals("M"))
                            {
                                if (dictTotalizadorDesempenhoMasculino.ContainsKey("velocidade"))
                                {
                                    veloVerificaAluno = true;

                                    var value = dictTotalizadorDesempenhoMasculino["velocidade"];

                                    value += 1;

                                    dictTotalizadorDesempenhoMasculino["velocidade"] = value;
                                }
                            }
                            else
                            {
                                if (dictTotalizadorDesempenhoFeminino.ContainsKey("velocidade"))
                                {
                                    veloVerificaAluno = true;

                                    var value = dictTotalizadorDesempenhoFeminino["velocidade"];

                                    value += 1;

                                    dictTotalizadorDesempenhoFeminino["velocidade"] = value;
                                }
                            }

                            var valueTotal = dict["velocidade"];

                            valueTotal += 1;

                            dict["velocidade"] = valueTotal;

                            break;
                        }
                    }

                    if (!impulsaoVerificaAluno)
                    {
                        if (aluno.TalentoEsportivo.ImpulsaoHorizontal >= item.PontoInicial && aluno.TalentoEsportivo.ImpulsaoHorizontal <= item.PontoFinal)
                        {
                            if (aluno.Sexo!.Equals("M"))
                            {
                                if (dictTotalizadorDesempenhoMasculino.ContainsKey("forcaExplosiva"))
                                {
                                    impulsaoVerificaAluno = true;

                                    var value = dictTotalizadorDesempenhoMasculino["forcaExplosiva"];

                                    value += 1;

                                    dictTotalizadorDesempenhoMasculino["forcaExplosiva"] = value;
                                }
                            }
                            else
                            {
                                if (dictTotalizadorDesempenhoFeminino.ContainsKey("forcaExplosiva"))
                                {
                                    impulsaoVerificaAluno = true;

                                    var value = dictTotalizadorDesempenhoFeminino["forcaExplosiva"];

                                    value += 1;

                                    dictTotalizadorDesempenhoFeminino["forcaExplosiva"] = value;
                                }
                            }

                            var valueTotal = dict["forcaExplosiva"];

                            valueTotal += 1;

                            dict["forcaExplosiva"] = valueTotal;

                            break;
                        }
                    }

                    if (!agilidadeVerificaAluno)
                    {
                        if (aluno.TalentoEsportivo.ShuttleRun >= item.PontoInicial && aluno.TalentoEsportivo.ShuttleRun <= item.PontoFinal)
                        {
                            if (aluno.Sexo!.Equals("M"))
                            {
                                if (dictTotalizadorDesempenhoMasculino.ContainsKey("agilidade"))
                                {
                                    agilidadeVerificaAluno = true;

                                    var value = dictTotalizadorDesempenhoMasculino["agilidade"];

                                    value += 1;

                                    dictTotalizadorDesempenhoMasculino["agilidade"] = value;
                                }
                            }
                            else
                            {
                                if (dictTotalizadorDesempenhoFeminino.ContainsKey("agilidade"))
                                {
                                    agilidadeVerificaAluno = true;

                                    var value = dictTotalizadorDesempenhoFeminino["agilidade"];

                                    value += 1;

                                    dictTotalizadorDesempenhoFeminino["agilidade"] = value;
                                }
                            }

                            var valueTotal = dict["agilidade"];

                            valueTotal += 1;

                            dict["agilidade"] = valueTotal;

                            break;
                        }
                    }

                    if (!shutlleRunVerificaAluno)
                    {
                        if (aluno.TalentoEsportivo.ShuttleRun >= item.PontoInicial && aluno.TalentoEsportivo.ShuttleRun <= item.PontoFinal)
                        {
                            if (aluno.Sexo!.Equals("M"))
                            {
                                if (dictTotalizadorDesempenhoMasculino.ContainsKey("shutlleRun"))
                                {
                                    shutlleRunVerificaAluno = true;

                                    var value = dictTotalizadorDesempenhoMasculino["shutlleRun"];

                                    value += 1;

                                    dictTotalizadorDesempenhoMasculino["shutlleRun"] = value;
                                }
                            }
                            else
                            {
                                if (dictTotalizadorDesempenhoFeminino.ContainsKey("shutlleRun"))
                                {
                                    shutlleRunVerificaAluno = true;

                                    var value = dictTotalizadorDesempenhoFeminino["shutlleRun"];

                                    value += 1;

                                    dictTotalizadorDesempenhoFeminino["shutlleRun"] = value;
                                }
                            }

                            var valueTotal = dict["shutlleRun"];

                            valueTotal += 1;

                            dict["shutlleRun"] = valueTotal;

                            break;
                        }
                    }

                    if (!flexibilidadeMuscularVerificaAluno)
                    {
                        if (aluno.TalentoEsportivo.Flexibilidade >= item.PontoInicial && aluno.TalentoEsportivo.Flexibilidade <= item.PontoFinal)
                        {
                            if (aluno.Sexo!.Equals("M"))
                            {
                                if (dictTotalizadorDesempenhoMasculino.ContainsKey("flexibilidadeMuscular"))
                                {
                                    flexibilidadeMuscularVerificaAluno = true;

                                    var value = dictTotalizadorDesempenhoMasculino["flexibilidadeMuscular"];

                                    value += 1;

                                    dictTotalizadorDesempenhoMasculino["flexibilidadeMuscular"] = value;
                                }
                            }
                            else
                            {
                                if (dictTotalizadorDesempenhoFeminino.ContainsKey("flexibilidadeMuscular"))
                                {
                                    flexibilidadeMuscularVerificaAluno = true;

                                    var value = dictTotalizadorDesempenhoFeminino["flexibilidadeMuscular"];

                                    value += 1;

                                    dictTotalizadorDesempenhoFeminino["flexibilidadeMuscular"] = value;
                                }
                            }

                            var valueTotal = dict["flexibilidadeMuscular"];

                            valueTotal += 1;

                            dict["flexibilidadeMuscular"] = valueTotal;

                            break;
                        }
                    }

                    if (!forcaMembrosSupVerificaAluno)
                    {
                        if (aluno.TalentoEsportivo.PreensaoManual >= item.PontoInicial && aluno.TalentoEsportivo.PreensaoManual <= item.PontoFinal)
                        {
                            if (aluno.Sexo!.Equals("M"))
                            {
                                if (dictTotalizadorDesempenhoMasculino.ContainsKey("forcaMembrosSup"))
                                {
                                    forcaMembrosSupVerificaAluno = true;

                                    var value = dictTotalizadorDesempenhoMasculino["forcaMembrosSup"];

                                    value += 1;

                                    dictTotalizadorDesempenhoMasculino["forcaMembrosSup"] = value;
                                }
                            }
                            else
                            {
                                if (dictTotalizadorDesempenhoFeminino.ContainsKey("forcaMembrosSup"))
                                {
                                    forcaMembrosSupVerificaAluno = true;

                                    var value = dictTotalizadorDesempenhoFeminino["forcaMembrosSup"];

                                    value += 1;

                                    dictTotalizadorDesempenhoFeminino["forcaMembrosSup"] = value;
                                }
                            }

                            var valueTotal = dict["forcaMembrosSup"];

                            valueTotal += 1;

                            dict["forcaMembrosSup"] = valueTotal;

                            break;
                        }
                    }

                    if (!aptidaoCardioVerificaAluno)
                    {
                        if (aluno.TalentoEsportivo.Vo2Max >= item.PontoInicial && aluno.TalentoEsportivo.Vo2Max <= item.PontoFinal)
                        {
                            if (aluno.Sexo!.Equals("M"))
                            {
                                if (dictTotalizadorDesempenhoMasculino.ContainsKey("aptidaoCardio"))
                                {
                                    aptidaoCardioVerificaAluno = true;

                                    var value = dictTotalizadorDesempenhoMasculino["aptidaoCardio"];

                                    value += 1;

                                    dictTotalizadorDesempenhoMasculino["aptidaoCardio"] = value;
                                }
                            }
                            else
                            {
                                if (dictTotalizadorDesempenhoFeminino.ContainsKey("aptidaoCardio"))
                                {
                                    aptidaoCardioVerificaAluno = true;

                                    var value = dictTotalizadorDesempenhoFeminino["aptidaoCardio"];

                                    value += 1;

                                    dictTotalizadorDesempenhoFeminino["aptidaoCardio"] = value;
                                }
                            }

                            var valueTotal = dict["aptidaoCardio"];

                            valueTotal += 1;

                            dict["aptidaoCardio"] = valueTotal;

                            break;
                        }
                    }

                    if (!vo2MaxVerificaAluno)
                    {
                        if (aluno.TalentoEsportivo.Vo2Max >= item.PontoInicial && aluno.TalentoEsportivo.Vo2Max <= item.PontoFinal)
                        {
                            if (aluno.Sexo!.Equals("M"))
                            {
                                if (dictTotalizadorDesempenhoMasculino.ContainsKey("vo2Max"))
                                {
                                    vo2MaxVerificaAluno = true;

                                    var value = dictTotalizadorDesempenhoMasculino["vo2Max"];

                                    value += 1;

                                    dictTotalizadorDesempenhoMasculino["vo2Max"] = value;
                                }
                            }
                            else
                            {
                                if (dictTotalizadorDesempenhoFeminino.ContainsKey("vo2Max"))
                                {
                                    vo2MaxVerificaAluno = true;

                                    var value = dictTotalizadorDesempenhoFeminino["vo2Max"];

                                    value += 1;

                                    dictTotalizadorDesempenhoFeminino["vo2Max"] = value;
                                }
                            }

                            var valueTotal = dict["vo2Max"];

                            valueTotal += 1;

                            dict["vo2Max"] = valueTotal;

                            break;
                        }
                    }

                    if (!resAbdominalVerificaAluno)
                    {
                        if (aluno.TalentoEsportivo.Abdominal >= item.PontoInicial && aluno.TalentoEsportivo.Abdominal <= item.PontoFinal)
                        {
                            if (aluno.Sexo!.Equals("M"))
                            {
                                if (dictTotalizadorDesempenhoMasculino.ContainsKey("resAbdominal"))
                                {
                                    resAbdominalVerificaAluno = true;

                                    var value = dictTotalizadorDesempenhoMasculino["resAbdominal"];

                                    value += 1;

                                    dictTotalizadorDesempenhoMasculino["resAbdominal"] = value;
                                }
                            }
                            else
                            {
                                if (dictTotalizadorDesempenhoFeminino.ContainsKey("resAbdominal"))
                                {
                                    resAbdominalVerificaAluno = true;

                                    var value = dictTotalizadorDesempenhoFeminino["resAbdominal"];

                                    value += 1;

                                    dictTotalizadorDesempenhoFeminino["resAbdominal"] = value;
                                }
                            }

                            var valueTotal = dict["vo2Max"];

                            valueTotal += 1;

                            dict["vo2Max"] = valueTotal;

                            break;
                        }
                    }

                    if (!pranchaVerificaAluno)
                    {
                        if (aluno.TalentoEsportivo.Abdominal >= item.PontoInicial && aluno.TalentoEsportivo.Abdominal <= item.PontoFinal)
                        {
                            if (aluno.Sexo!.Equals("M"))
                            {
                                if (dictTotalizadorDesempenhoMasculino.ContainsKey("resAbdominal"))
                                {
                                    resAbdominalVerificaAluno = true;

                                    var value = dictTotalizadorDesempenhoMasculino["resAbdominal"];

                                    value += 1;

                                    dictTotalizadorDesempenhoMasculino["resAbdominal"] = value;
                                }
                            }
                            else
                            {
                                if (dictTotalizadorDesempenhoFeminino.ContainsKey("resAbdominal"))
                                {
                                    resAbdominalVerificaAluno = true;

                                    var value = dictTotalizadorDesempenhoFeminino["resAbdominal"];

                                    value += 1;

                                    dictTotalizadorDesempenhoFeminino["resAbdominal"] = value;
                                }
                            }

                            var valueTotal = dict["resAbdominal"];

                            valueTotal += 1;

                            dict["resAbdominal"] = valueTotal;

                            break;
                        }
                    }
                }
            }
        }

        var totalMasc = dictTotalizadorDesempenhoMasculino.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percTotalizadorDesempenhoMasculino = dictTotalizadorDesempenhoMasculino.Where(item => totalMasc != 0).ToDictionary(item => item.Key!, item => 100 * item.Value / totalMasc);

        var totalFem = dictTotalizadorDesempenhoFeminino.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percTotalizadorDesempenhoFeminino = dictTotalizadorDesempenhoFeminino.Where(item => totalFem != 0).ToDictionary(item => item.Key!, item => 100 * item.Value / totalFem);

        var total = dict.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percDesempenho = dict.Where(item => total != 0).ToDictionary(item => item.Key!, item => 100 * item.Value / total);

        return new TotalizadorDesempenhoDto
        {
            ValorTotalizadorDesempenhoMasculino = dictTotalizadorDesempenhoMasculino,
            ValorTotalizadorDesempenhoFeminino = dictTotalizadorDesempenhoFeminino,
            PercTotalizadorDesempenhoMasculino = percTotalizadorDesempenhoMasculino,
            PercTotalizadorDesempenhoFeminino = percTotalizadorDesempenhoFeminino,
            PercDesempenho = percDesempenho
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

