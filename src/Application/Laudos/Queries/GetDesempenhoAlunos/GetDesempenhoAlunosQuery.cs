using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Common.Models;
using DnaBrasilApi.Application.Cursos.Queries;
using DnaBrasilApi.Application.Dashboards.Queries;
using DnaBrasilApi.Application.MetricasImc.Queries.GetMetricaImcById;
using DnaBrasilApi.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace DnaBrasilApi.Application.Laudos.Queries.GetDesempenhoAlunos;
//[Authorize]
public record GetDesempenhoAlunosQuery(int id) : IRequest<DesempenhoDto>;

public class GetDesempenhoAlunosQueryHandler : IRequestHandler<GetDesempenhoAlunosQuery, DesempenhoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDesempenhoAlunosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<DesempenhoDto> Handle(GetDesempenhoAlunosQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Aluno> alunos;
        IQueryable<Laudo> laudo;

        alunos = _context.Alunos
            .Where(x => x.Id == request.id)//37315 - Feminino 38438
            .AsNoTracking();

        laudo = _context.Laudos
            .AsNoTracking()
            .Where(x => x.Aluno.Id == request.id);

        var result = FilterDesempenhoAlunos(alunos, laudo, cancellationToken);

        return result;
    }

    private async Task<DesempenhoDto> FilterDesempenhoAlunos(IQueryable<Aluno> alunos,
        IQueryable<Laudo> laudo, CancellationToken cancellationToken)
    {
        var desempenhosEsportivos = await _context.TextosLaudos
            .Where(x => x.Status && x.TipoLaudo!.Id == 4)
            .Select(s => s.Classificacao)
            .Distinct()
            .ToListAsync();

        var desempenhosImcs = await _context.TextosLaudos
            .Where(x => x.Status && x.TipoLaudo!.Id == 9)
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
            
            { "shutlleRun", 0 },
            { "prancha", 0 },
            { "vo2Max", 0 },

            { "imc", 0}
        };

        Dictionary<string, decimal> dictDesempenhoMasculino = new()
        {
            { "velocidade", 0 },
            { "flexibilidadeMuscular", 0 },
            { "forcaMembrosSup", 0 },
            { "forcaExplosiva", 0 },
            { "aptidaoCardio", 0 },
            
            { "shutlleRun", 0 },
            { "prancha", 0 },
            { "vo2Max", 0 },

            { "imc", 0}
        };
        Dictionary<string, decimal> dictDesempenhoFeminino = new()
        {
            { "velocidade", 0 },
            { "flexibilidadeMuscular", 0 },
            { "forcaMembrosSup", 0 },
            { "forcaExplosiva", 0 },
            { "aptidaoCardio", 0 },

            { "shutlleRun", 0 },
            { "prancha", 0 },
            { "vo2Max", 0 },

            { "imc", 0}
        };

        List<TextoLaudo> textoLaudo = new();
        //List<string>? encaminhamento = new List<string>();

        var verificaAlunos = alunos.Select(x => x.Id);

        var laudosEsportvios = _context.Laudos.Where(x => verificaAlunos.Contains(x.Aluno.Id)).Include(i => i.TalentoEsportivo).Where(x => x.TalentoEsportivo != null)
            .Include(a => a.Aluno)
            .AsNoTracking();

        var laudosImcs = _context.Laudos.Where(x => verificaAlunos.Contains(x.Aluno.Id)).Include(i => i.Saude).Where(x => x.Saude != null)
            .Include(a => a.Aluno)
            .AsNoTracking();

        //var contador = 0;

        double velocidade = 0;
        double impulsao =0;
        double shutlleRun = 0;
        double flexibilidadeMuscular = 0;
        double forcaMembrosSup = 0;
        double aptidaoCardio = 0;
        double prancha = 0;

        int imcSaude = 0;

        foreach (var aluno in laudosEsportvios)
        {
            if (aluno.TalentoEsportivo == null)
            {
                continue;
            }

            var idade = GetIdade(aluno.Aluno.DtNascimento, DateTime.Now);

            //var modalidades = _context.Modalidades
            //    .Where(x => x.Status == true).ToList();

            foreach (var desempenho in desempenhosEsportivos)
            {
                textoLaudo = _context.TextosLaudos.Where(x =>
                    x.Status &&
                    x.Classificacao!.Equals(desempenho) &&
                    x.Idade == idade &&
                    (x.Aviso!.Trim() == "Excelente" || x.Aviso!.Trim() == "Muito Bom" || x.Aviso!.Trim() == "Bom" || x.Aviso!.Trim() == "Razoavel" || x.Aviso!.Trim() == "Fraco" || x.Aviso!.Trim() == "Muito fraco") &&
                    x.Sexo == (idade == 99 ? "G" : aluno.Aluno.Sexo)).ToList();

                foreach (var item in textoLaudo)
                {
                    switch (item.Classificacao)
                    {
                        case "Velocidade" when
                            aluno.TalentoEsportivo.Velocidade >= item.PontoInicial &&
                            aluno.TalentoEsportivo.Velocidade <= item.PontoFinal:
                            {
                                var nota = item.Aviso;
                                switch (aluno.Aluno.Sexo!)
                                {
                                    case "M":
                                        {
                                            if (dictDesempenhoMasculino.ContainsKey("velocidade"))
                                            {
                                                var value = dictDesempenhoMasculino["velocidade"];

                                                value += 1;

                                                dictDesempenhoMasculino["velocidade"] = value;
                                            }

                                            break;
                                        }
                                    default:
                                        {
                                            if (dictDesempenhoFeminino.ContainsKey("velocidade"))
                                            {
                                                var value = dictDesempenhoFeminino["velocidade"];

                                                value += 1;

                                                dictDesempenhoFeminino["velocidade"] = value;
                                            }

                                            break;
                                        }
                                }

                                var valueTotal = dict["velocidade"];

                                valueTotal += 1;

                                dict["velocidade"] = valueTotal;

                                velocidade = nota switch
                                {
                                    "Muito fraco" => 0,
                                    "Fraco" => 5,
                                    "Razoavel" => 7,
                                    "Bom" => 9,
                                    "Muito Bom" => 12,
                                    "Excelente" => 14.28,
                                    _ => 0
                                };

                                //encaminhamento!.AddRange(modalidades
                                //    .Where(x => velocidade >= x.VinteMetrosIni && velocidade <= x.VinteMetrosFim)
                                //    .Select(s => s.Nome).ToList()!);

                                break;
                            }
                        case "Impulsão" when
                            aluno.TalentoEsportivo.ImpulsaoHorizontal >= item.PontoInicial &&
                            aluno.TalentoEsportivo.ImpulsaoHorizontal <= item.PontoFinal:
                            {
                                var nota = item.Aviso;
                                switch (aluno.Aluno.Sexo!)
                                {
                                    case "M":
                                        {
                                            if (dictDesempenhoMasculino.ContainsKey("forcaExplosiva"))
                                            {
                                                var value = dictDesempenhoMasculino["forcaExplosiva"];

                                                value += 1;

                                                dictDesempenhoMasculino["forcaExplosiva"] = value;
                                            }

                                            break;
                                        }
                                    default:
                                        {
                                            if (dictDesempenhoFeminino.ContainsKey("forcaExplosiva"))
                                            {
                                                var value = dictDesempenhoFeminino["forcaExplosiva"];

                                                value += 1;

                                                dictDesempenhoFeminino["forcaExplosiva"] = value;
                                            }

                                            break;
                                        }
                                }

                                var valueTotal = dict["forcaExplosiva"];

                                valueTotal += 1;

                                dict["forcaExplosiva"] = valueTotal;

                                impulsao = nota switch
                                {   
                                    "Muito fraco" => 0,
                                    "Fraco" => 5,
                                    "Razoavel" => 7,
                                    "Bom" => 9,
                                    "Muito Bom" => 12,
                                    "Excelente" => 14.28,
                                    _ => 0
                                };

                                //encaminhamento!.AddRange(modalidades
                                //    .Where(x => impulsao >= x.ImpulsaoIni && impulsao <= x.ImpulsaoFim)
                                //    .Select(s => s.Nome).ToList()!);
                                break;
                            }
                        case "Agilidade ou Shuttle run" when
                            aluno.TalentoEsportivo.ShuttleRun >= item.PontoInicial &&
                            aluno.TalentoEsportivo.ShuttleRun <= item.PontoFinal:
                            {
                                var nota = item.Aviso;
                                switch (aluno.Aluno.Sexo!)
                                {
                                    case "M":
                                        {
                                            if (dictDesempenhoMasculino.ContainsKey("shutlleRun"))
                                            {
                                                var value = dictDesempenhoMasculino["shutlleRun"];

                                                value += 1;

                                                dictDesempenhoMasculino["shutlleRun"] = value;
                                            }

                                            break;
                                        }
                                    default:
                                        {
                                            if (dictDesempenhoFeminino.ContainsKey("shutlleRun"))
                                            {
                                                var value = dictDesempenhoFeminino["shutlleRun"];

                                                value += 1;

                                                dictDesempenhoFeminino["shutlleRun"] = value;
                                            }

                                            break;
                                        }
                                }

                                var valueTotal = dict["shutlleRun"];

                                valueTotal += 1;

                                dict["shutlleRun"] = valueTotal;

                                shutlleRun = nota switch
                                {
                                    "Muito fraco" => 0,
                                    "Fraco" => 5,
                                    "Razoavel" => 7,
                                    "Bom" => 9,
                                    "Muito Bom" => 12,
                                    "Excelente" => 14.28,
                                    _ => 0
                                };

                                //encaminhamento!.AddRange(modalidades
                                //    .Where(x => shutlleRun >= x.ShutlleRunIni && shutlleRun <= x.ShutlleRunFim)
                                //    .Select(s => s.Nome).ToList()!);
                                break;
                            }
                        case "Flexibilidade" when
                            aluno.TalentoEsportivo.Flexibilidade >= item.PontoInicial &&
                            aluno.TalentoEsportivo.Flexibilidade <= item.PontoFinal:
                            {
                                var nota = item.Aviso;
                                switch (aluno.Aluno.Sexo!)
                                {
                                    case "M":
                                        {
                                            if (dictDesempenhoMasculino.ContainsKey("flexibilidadeMuscular"))
                                            {
                                                var value = dictDesempenhoMasculino["flexibilidadeMuscular"];

                                                value += 1;

                                                dictDesempenhoMasculino["flexibilidadeMuscular"] = value;
                                            }

                                            break;
                                        }
                                    default:
                                        {
                                            if (dictDesempenhoFeminino.ContainsKey("flexibilidadeMuscular"))
                                            {
                                                var value = dictDesempenhoFeminino["flexibilidadeMuscular"];

                                                value += 1;

                                                dictDesempenhoFeminino["flexibilidadeMuscular"] = value;
                                            }

                                            break;
                                        }
                                }

                                var valueTotal = dict["flexibilidadeMuscular"];

                                valueTotal += 1;

                                dict["flexibilidadeMuscular"] = valueTotal;

                                flexibilidadeMuscular = nota switch
                                {
                                    "Muito fraco" => 0,
                                    "Fraco" => 5,
                                    "Razoavel" => 7,
                                    "Bom" => 9,
                                    "Muito Bom" => 12,
                                    "Excelente" => 14.28,
                                    _ => 0
                                };

                                //encaminhamento!.AddRange(modalidades
                                //    .Where(x => flexibilidadeMuscular >= x.FlexibilidadeIni &&
                                //                flexibilidadeMuscular <= x.FlexibilidadeFim)
                                    //.Select(s => s.Nome).ToList()!);
                                break;
                            }
                        case "Preensão Manual" when
                            aluno.TalentoEsportivo.PreensaoManual >= item.PontoInicial &&
                            aluno.TalentoEsportivo.PreensaoManual <= item.PontoFinal:
                            {
                                var nota = item.Aviso;
                                switch (aluno.Aluno.Sexo!)
                                {
                                    case "M":
                                        {
                                            if (dictDesempenhoMasculino.ContainsKey("forcaMembrosSup"))
                                            {
                                                var value = dictDesempenhoMasculino["forcaMembrosSup"];

                                                value += 1;

                                                dictDesempenhoMasculino["forcaMembrosSup"] = value;
                                            }

                                            break;
                                        }
                                    default:
                                        {
                                            if (dictDesempenhoFeminino.ContainsKey("forcaMembrosSup"))
                                            {
                                                var value = dictDesempenhoFeminino["forcaMembrosSup"];

                                                value += 1;

                                                dictDesempenhoFeminino["forcaMembrosSup"] = value;
                                            }

                                            break;
                                        }
                                }

                                var valueTotal = dict["forcaMembrosSup"];

                                valueTotal += 1;

                                dict["forcaMembrosSup"] = valueTotal;

                                forcaMembrosSup = nota switch
                                {
                                    "Muito fraco" => 0,
                                    "Fraco" => 5,
                                    "Razoavel" => 7,
                                    "Bom" => 9,
                                    "Muito Bom" => 12,
                                    "Excelente" => 14.28,
                                    _ => 0
                                };

                                //encaminhamento!.AddRange(modalidades
                                //    .Where(x => forcaMembrosSup >= x.PreensaoManualIni &&
                                //                forcaMembrosSup <= x.PreensaoManualFim)
                                //    .Select(s => s.Nome).ToList()!);
                                break;
                            }
                        case "Vo2 Max" when 
                            aluno.TalentoEsportivo.Vo2Max >= item.PontoInicial &&
                            aluno.TalentoEsportivo.Vo2Max <= item.PontoFinal:
                            {
                                var nota = item.Aviso;
                                switch (aluno.Aluno.Sexo!)
                                {
                                    case "M":
                                        {
                                            if (dictDesempenhoMasculino.ContainsKey("aptidaoCardio"))
                                            {
                                                var value = dictDesempenhoMasculino["aptidaoCardio"];

                                                value += 1;

                                                dictDesempenhoMasculino["aptidaoCardio"] = value;
                                            }

                                            break;
                                        }
                                    default:
                                        {
                                            if (dictDesempenhoFeminino.ContainsKey("aptidaoCardio"))
                                            {
                                                var value = dictDesempenhoFeminino["aptidaoCardio"];

                                                value += 1;

                                                dictDesempenhoFeminino["aptidaoCardio"] = value;
                                            }

                                            break;
                                        }
                                }

                                var valueTotal = dict["aptidaoCardio"];

                                valueTotal += 1;

                                dict["aptidaoCardio"] = valueTotal;

                                aptidaoCardio = nota switch
                                {
                                    "Muito fraco" => 0,
                                    "Fraco" => 5,
                                    "Razoavel" => 7,
                                    "Bom" => 9,
                                    "Muito Bom" => 12,
                                    "Excelente" => 14.28,
                                    _ => 0
                                };

                                //encaminhamento!.AddRange(modalidades
                                //    .Where(x => aptidaoCardio >= x.Vo2MaxIni && aptidaoCardio <= x.Vo2MaxFim)
                                //    .Select(s => s.Nome).ToList()!);
                                break;
                            }
                        case "Prancha (ABD)" when
                            aluno.TalentoEsportivo.Abdominal >= item.PontoInicial &&
                            aluno.TalentoEsportivo.Abdominal <= item.PontoFinal:
                            {
                                var nota = item.Aviso;
                                switch (aluno.Aluno.Sexo!)
                                {
                                    case "M":
                                        {
                                            if (dictDesempenhoMasculino.ContainsKey("prancha"))
                                            {
                                                var value = dictDesempenhoMasculino["prancha"];

                                                value += 1;

                                                dictDesempenhoMasculino["prancha"] = value;
                                            }

                                            break;
                                        }
                                    default:
                                        {
                                            if (dictDesempenhoFeminino.ContainsKey("prancha"))
                                            {
                                                var value = dictDesempenhoFeminino["prancha"];

                                                value += 1;

                                                dictDesempenhoFeminino["prancha"] = value;
                                            }

                                            break;
                                        }
                                }

                                var valueTotal = dict["prancha"];

                                valueTotal += 1;

                                dict["prancha"] = valueTotal;

                                prancha = nota switch
                                {
                                    "Muito fraco" => 0,
                                    "Fraco" => 5,
                                    "Razoavel" => 7,
                                    "Bom" => 9,
                                    "Muito Bom" => 12,
                                    "Excelente" => 14.28,
                                    _ => 0
                                };
                               
                                //encaminhamento!.AddRange(modalidades
                                //    .Where(x => prancha >= x.AbdominalPranchaIni && prancha <= x.AbdominalPranchaFim)
                                //    .Select(s => s.Nome).ToList()!);
                                break;
                            }
                    }
                }
            }
        }

        foreach (var aluno in laudosImcs)
        {
            if (aluno.Saude == null)
            {
                continue;
            }

            var idade = GetIdade(aluno.Aluno.DtNascimento, DateTime.Now);

            var imc = GetImc(aluno.Saude!.Massa, aluno.Saude!.Altura);
            var decimalImc = Convert.ToDecimal(imc);

            //var modalidades = _context.Modalidades
            //    .Where(x => x.Status == true).ToList();

            foreach (var desempenho in desempenhosImcs)
            {
                textoLaudo = _context.TextosLaudos.Where(x =>
                    x.Status &&
                    x.Classificacao!.Equals(desempenho) &&
                    x.Idade == idade &&
                    (x.Aviso!.Trim() == "ABAIXODONORMAL" || x.Aviso!.Trim() == "NORMAL" || x.Aviso!.Trim() == "OBESIDADE" ||
                     x.Aviso!.Trim() == "SOBREPESO") &&
                    x.Sexo == (idade == 99 ? "G" : aluno.Aluno.Sexo)).ToList();

                foreach (var item in textoLaudo)
                {
                    if (decimalImc >= item.PontoInicial && decimalImc <= item.PontoFinal)
                    {
                        var nota = item.Aviso;

                        switch (aluno.Aluno.Sexo!)
                        {
                            case "M":
                                {
                                    if (dictDesempenhoMasculino.ContainsKey("imc"))
                                    {
                                        var value = dictDesempenhoMasculino["imc"];
                                        value += 1;
                                        dictDesempenhoMasculino["imc"] = value;
                                    }
                                    break;
                                }
                            default:
                                {
                                    if (dictDesempenhoFeminino.ContainsKey("imc"))
                                    {
                                        var value = dictDesempenhoFeminino["imc"];
                                        value += 1;
                                        dictDesempenhoFeminino["imc"] = value;
                                    }
                                    break;
                                }
                        }

                        if (dict.ContainsKey("imc"))
                        {
                            var valueTotal = dict["imc"];
                            valueTotal += 1;
                            dict["imc"] = valueTotal;
                        }

                        imcSaude = nota switch
                        {
                            "ABAIXODONORMAL" => 50,
                            "NORMAL" => 100,
                            "OBESIDADE" => 25,
                            "SOBREPESO" => 0,
                            _ => 0
                        };

                        break;
                    }
                }

            }
        }

        var scoreVocacional = 0;

        if (laudo.Any(x => x.Vocacional != null))
        {
            scoreVocacional = 100;
        }


        var scoreTalentoEsportivo = velocidade + impulsao + shutlleRun + flexibilidadeMuscular
                                    + forcaMembrosSup + aptidaoCardio + prancha;

        var scoreSaude = imcSaude;

            return new DesempenhoDto()
            {
                ScoreTalentoEsportivo = Round(scoreTalentoEsportivo),
                ScoreSaude = scoreSaude,

                ScoreVocacional = scoreVocacional,
                ScoreDna = Round(scoreTalentoEsportivo + scoreSaude + scoreVocacional)
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

            return YearsOld >= 18 ? 99 : YearsOld < 4 ? 4 : YearsOld;
        }
        catch
        {
            return 0;
        }
    }
    private static int Round(double number)
    {
        if (number - (int)number >= 0.5)
        {
            number = (int)number + 1;
        }
        else
        {
            number = (int)number;
        }

        return (int)number;
    }
    public static string GetImc(decimal? massa, decimal? altura)
    {
        try
        {
            var inteiro = massa! * 100 * 100;
            var dividendo = altura * altura;
            var result = Convert.ToDecimal(inteiro) / Convert.ToDecimal(dividendo);

            Double doublVal = Convert.ToDouble(String.Format("{0:0.00}", result));

            return doublVal.ToString();

        }
        catch
        {
            return 0.ToString();
        }
    }
}
