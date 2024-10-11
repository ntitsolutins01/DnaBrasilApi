using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using DnaBrasilApi.Application.Encaminhamentos.Queries;
using System.Threading;

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
        IQueryable<Aluno> aluno;
        IQueryable<Laudo> laudo;

        aluno = _context.Alunos
            .Where(x => x.Id == request.id)//37315 - Feminino 38438
            .AsNoTracking();

        laudo = _context.Laudos
            .AsNoTracking()
            .Include(x => x.Aluno) // Carrega o relacionamento com Aluno
            .Include(x => x.SaudeBucal) // Exemplo de outra propriedade relacionada
            .Include(x => x.SaudeBucal!.Encaminhamento) // Exemplo de outra propriedade relacionada
            .Where(x => x.Aluno.Id == request.id);


        var result = DesempenhoAlunos(aluno, laudo, cancellationToken);

        return result;
    }

    private async Task<DesempenhoDto> DesempenhoAlunos(IQueryable<Aluno> aluno,
        IQueryable<Laudo> laudo, CancellationToken cancellationToken)
    {
        var desempenhoEsportivo = await _context.TextosLaudos
            .Where(x => x.Status && x.TipoLaudo!.Id == 4)
            .Select(s => s.Classificacao)
            .Distinct()
            .ToListAsync();

        var desempenhoImc = await _context.TextosLaudos
            .Where(x => x.Status && x.TipoLaudo!.Id == 9)
            .Select(s => s.Classificacao)
            .Distinct()
            .ToListAsync();

        var desempenhoSaudeBucal = await _context.TextosLaudos
            .Where(x => x.TipoLaudo!.Id == 5)
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

            { "imc", 0 },

            { "saudeBucal", 0 }
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

            { "imc", 0 },

            { "saudeBucal", 0 }
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

            { "imc", 0 },

            { "saudeBucal", 0 }
        };

        List<TextoLaudo> textoLaudo = new();
        //List<string>? encaminhamento = new List<string>();

        var verificaAluno = aluno.Select(x => x.Id);

        var laudoEsportivo = _context.Laudos.Where(x => verificaAluno.Contains(x.Aluno.Id)).Include(i => i.TalentoEsportivo).Where(x => x.TalentoEsportivo != null)
            .Include(a => a.Aluno)
            .AsNoTracking();

        var laudoImc = _context.Laudos.Where(x => verificaAluno.Contains(x.Aluno.Id)).Include(i => i.Saude).Where(x => x.Saude != null)
            .Include(a => a.Aluno)
            .AsNoTracking();

        var laudoSaudeBucal = _context.Laudos.Where(x => verificaAluno.Contains(x.Aluno.Id)).Include(i => i.SaudeBucal).Where(x => x.SaudeBucal != null)
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

        int saudeBucal = 0;

        var alunoEportivo = laudoEsportivo.FirstOrDefault();
        if (alunoEportivo?.TalentoEsportivo != null)
        {
            var idade = GetIdade(alunoEportivo.Aluno.DtNascimento, DateTime.Now);

            foreach (var desempenho in desempenhoEsportivo)
            {
                textoLaudo = _context.TextosLaudos.Where(x =>
                    x.Status &&
                    x.Classificacao!.Equals(desempenho) &&
                    x.Idade == idade &&
                    (x.Aviso!.Trim() == "Excelente" || x.Aviso!.Trim() == "Muito Bom" || x.Aviso!.Trim() == "Bom" || x.Aviso!.Trim() == "Razoavel" || x.Aviso!.Trim() == "Fraco" || x.Aviso!.Trim() == "Muito fraco") &&
                    x.Sexo == (idade == 99 ? "G" : alunoEportivo.Aluno.Sexo)).ToList();

                foreach (var item in textoLaudo)
                {
                    switch (item.Classificacao)
                    {
                        case "Velocidade" when
                            alunoEportivo.TalentoEsportivo.Velocidade >= item.PontoInicial &&
                            alunoEportivo.TalentoEsportivo.Velocidade <= item.PontoFinal:
                            {
                                var nota = item.Aviso;
                                switch (alunoEportivo.Aluno.Sexo!)
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
                            alunoEportivo.TalentoEsportivo.ImpulsaoHorizontal >= item.PontoInicial &&
                            alunoEportivo.TalentoEsportivo.ImpulsaoHorizontal <= item.PontoFinal:
                            {
                                var nota = item.Aviso;
                                switch (alunoEportivo.Aluno.Sexo!)
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
                            alunoEportivo.TalentoEsportivo.ShuttleRun >= item.PontoInicial &&
                            alunoEportivo.TalentoEsportivo.ShuttleRun <= item.PontoFinal:
                            {
                                var nota = item.Aviso;
                                switch (alunoEportivo.Aluno.Sexo!)
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
                            alunoEportivo.TalentoEsportivo.Flexibilidade >= item.PontoInicial &&
                            alunoEportivo.TalentoEsportivo.Flexibilidade <= item.PontoFinal:
                            {
                                var nota = item.Aviso;
                                switch (alunoEportivo.Aluno.Sexo!)
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
                            alunoEportivo.TalentoEsportivo.PreensaoManual >= item.PontoInicial &&
                            alunoEportivo.TalentoEsportivo.PreensaoManual <= item.PontoFinal:
                            {
                                var nota = item.Aviso;
                                switch (alunoEportivo.Aluno.Sexo!)
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
                            alunoEportivo.TalentoEsportivo.Vo2Max >= item.PontoInicial &&
                            alunoEportivo.TalentoEsportivo.Vo2Max <= item.PontoFinal:
                            {
                                var nota = item.Aviso;
                                switch (alunoEportivo.Aluno.Sexo!)
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
                            alunoEportivo.TalentoEsportivo.Abdominal >= item.PontoInicial &&
                            alunoEportivo.TalentoEsportivo.Abdominal <= item.PontoFinal:
                            {
                                var nota = item.Aviso;
                                switch (alunoEportivo.Aluno.Sexo!)
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

        var alunoSaude = laudoImc.FirstOrDefault();
        if (alunoSaude?.Saude != null)
        {
            var idade = GetIdade(alunoSaude.Aluno.DtNascimento, DateTime.Now);

            var imc = GetImc(alunoSaude.Saude.Massa, alunoSaude.Saude.Altura);
            var decimalImc = Convert.ToDecimal(imc);

            var desempenho = desempenhoImc.FirstOrDefault();

            if (desempenho != null)
            {
                textoLaudo = _context.TextosLaudos.Where(x =>
                    x.Status &&
                    x.Classificacao!.Equals(desempenho) &&
                    x.Idade == idade &&
                    (x.Aviso!.Trim() == "ABAIXODONORMAL" || x.Aviso!.Trim() == "NORMAL" || x.Aviso!.Trim() == "OBESIDADE" ||
                     x.Aviso!.Trim() == "SOBREPESO") &&
                    x.Sexo == (idade == 99 ? "G" : alunoSaude.Aluno.Sexo)).ToList();

                var item = textoLaudo.FirstOrDefault(x => decimalImc >= x.PontoInicial && decimalImc <= x.PontoFinal);

                if (item != null)
                {
                    var nota = item.Aviso;

                    if (alunoSaude.Aluno.Sexo == "M")
                    {
                        if (dictDesempenhoMasculino.ContainsKey("imc"))
                        {
                            dictDesempenhoMasculino["imc"] += 1;
                        }
                    }
                    else
                    {
                        if (dictDesempenhoFeminino.ContainsKey("imc"))
                        {
                            dictDesempenhoFeminino["imc"] += 1;
                        }
                    }

                    if (dict.ContainsKey("imc"))
                    {
                        dict["imc"] += 1;
                    }

                    imcSaude = nota switch
                    {
                        "ABAIXODONORMAL" => 50,
                        "NORMAL" => 100,
                        "OBESIDADE" => 25,
                        "SOBREPESO" => 0,
                        _ => 0
                    };
                }
            }
        }

        var alunoSaudeBucal = laudoSaudeBucal.FirstOrDefault();

        if (alunoSaudeBucal?.SaudeBucal != null)
        {
            foreach (var desempenho in desempenhoSaudeBucal)
            {
                textoLaudo = _context.TextosLaudos
                    .Where(x =>
                        x.Classificacao!.Equals(desempenho) &&
                        (x.Aviso!.Trim().Equals("CUIDADO.CUIDADO") ||
                         x.Aviso.Trim().Equals("ATENCAO.ATENÇÃO") ||
                         x.Aviso.Trim().Equals("MUITOBOM.MUITO BOM")))
                    .ToList();

                var param = laudo.FirstOrDefault()?.SaudeBucal?.Encaminhamento?.Parametro?.Trim();

                var paramNormalized = param switch
                {
                    "ATENCAO" => "ATENCAO.ATENÇÃO",
                    "CUIDADO" => "CUIDADO.CUIDADO",
                    "MUITOBOM" => "MUITOBOM.MUITO BOM",
                    _ => param
                };

                if (textoLaudo.Any())
                {
                    foreach (var laudoItem in textoLaudo)
                    {
                        var avisoLaudo = laudoItem.Aviso?.Trim();

                        if (avisoLaudo!.Equals(paramNormalized))
                        {
                            var nota = laudoItem.Aviso;

                            if (alunoSaudeBucal.Aluno.Sexo == "M")
                            {
                                if (dictDesempenhoMasculino.ContainsKey("saudeBucal"))
                                {
                                    dictDesempenhoMasculino["saudeBucal"] += 1;
                                }
                            }
                            else
                            {
                                if (dictDesempenhoFeminino.ContainsKey("saudeBucal"))
                                {
                                    dictDesempenhoFeminino["saudeBucal"] += 1;
                                }
                            }

                            if (dict.ContainsKey("saudeBucal"))
                            {
                                dict["saudeBucal"] += 1;
                            }

                            saudeBucal = nota switch
                            {
                                "CUIDADO.CUIDADO" => 25,
                                "ATENCAO.ATENÇÃO" => 50,
                                "MUITOBOM.MUITO BOM" => 100,
                                _ => 0
                            };

                            break;
                        }
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
                ScoreSaudeBucal = saudeBucal,
                ScoreDna = Round(scoreTalentoEsportivo + scoreSaude + scoreVocacional + saudeBucal)
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
    private static string GetImc(decimal? massa, decimal? altura)
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
