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
            .Include(x => x.Aluno)
            .Include(x => x.SaudeBucal) 
            .Include(x => x.SaudeBucal!.Encaminhamento)
            .Include(x => x.ConsumoAlimentar)
            .Include(x => x.ConsumoAlimentar!.Encaminhamento)
            .Include(x => x.QualidadeDeVida)
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

        var desempenhoVida = await _context.TextosLaudos
            .Where(x => x.TipoLaudo!.Id == 7)
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

        var desempenhoConsumoAlimentar = await _context.TextosLaudos
            .Where(x => x.TipoLaudo!.Id == 8)
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

            { "saudeBucal", 0 },

            { "consumoAlimentar", 0 }
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

            { "saudeBucal", 0 },

            { "consumoAlimentar", 0 }
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

            { "saudeBucal", 0 },

            { "consumoAlimentar", 0 }
        };

        List<TextoLaudo> textoLaudo = new();

        var verificaAluno = aluno.Select(x => x.Id);

        var laudoEsportivo = _context.Laudos.Where(x => verificaAluno.Contains(x.Aluno.Id)).Include(i => i.TalentoEsportivo).Where(x => x.TalentoEsportivo != null)
            .Include(a => a.Aluno)
            .AsNoTracking();

        var laudoVida = _context.Laudos.Where(x => verificaAluno.Contains(x.Aluno.Id)).Include(i => i.QualidadeDeVida).Where(x => x.QualidadeDeVida != null)
            .Include(a => a.Aluno)
            .AsNoTracking();

        var laudoImc = _context.Laudos.Where(x => verificaAluno.Contains(x.Aluno.Id)).Include(i => i.Saude).Where(x => x.Saude != null)
            .Include(a => a.Aluno)
            .AsNoTracking();

        var laudoSaudeBucal = _context.Laudos.Where(x => verificaAluno.Contains(x.Aluno.Id)).Include(i => i.SaudeBucal).Where(x => x.SaudeBucal != null)
            .Include(a => a.Aluno)
            .AsNoTracking();

        var laudoConsumoAlimentar = _context.Laudos.Where(x => verificaAluno.Contains(x.Aluno.Id)).Include(i => i.ConsumoAlimentar).Where(x => x.ConsumoAlimentar != null)
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

        int consumoAlimentar = 0;

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

        int scoreQualidadeVida = 0;

        var alunoVida = laudoVida.FirstOrDefault();

        if (alunoVida?.QualidadeDeVida != null)
        {
            var desempenho = desempenhoVida.FirstOrDefault();
            if (desempenho != null)
            {
                textoLaudo = _context.TextosLaudos
                    .Where(x =>
                        x.Classificacao!.Equals(desempenho) &&
                        (x.Aviso!.Trim().Equals("BemEstarFisico.Bem estar físico") ||
                         x.Aviso.Trim().Equals("MalEstarFisico.Mal estar físico") ||
                         x.Aviso.Trim().Equals("AutoEstima.Autoestima e estabilidade emocional") ||
                         x.Aviso.Trim().Equals("BaixaAutoEstima.Baixa autoestima e dificuldades emocionais") ||
                         x.Aviso.Trim().Equals("FuncionamentoHarmonico.Funcionamento harmônico familiar") ||
                         x.Aviso.Trim().Equals("Conflitos.Conflitos no contexto familiar") ||
                         x.Aviso.Trim().Equals("ContextosFavorecedores.Contextos favorecedores do desenvolvimento") ||
                         x.Aviso.Trim().Equals("ContextosNaoFavorecedores.Contextos não favorecedores do desenvolvimento")))
                    .ToList();

                var encaminhamentos = laudo.FirstOrDefault()?.QualidadeDeVida?.Encaminhamentos;

                if (encaminhamentos != null && textoLaudo.Any())
                {
                    foreach (var param in encaminhamentos.Split(','))
                    {
                        var paramNormalized = param switch
                        {
                            "40" => "BEMESTARFISICO.BEM ESTAR FÍSICO",
                            "58" => "MALESTARFISICO.MAL ESTAR FÍSICO",
                            "62" => "AUTOESTIMA.AUTOESTIMA E ESTABILIDADE EMOCIONAL",
                            "64" => "BAIXAAUTOESTIMA.BAIXA AUTOESTIMA E DIFICULDADES EMOCIONAIS",
                            "66" => "FUNCIONAMENTOHARMONICO.FUNCIONAMENTO HARMÔNICO FAMILIAR",
                            "67" => "CONFLITOS.CONFLITOS NO CONTEXTO FAMILIAR",
                            "68" => "CONTEXTOSFAVORECEDORES.CONTEXTOS FAVORECEDORES DO DESENVOLVIMENTO",
                            "77" => "CONTEXTOSNAOFAVORECEDORES.CONTEXTOS NÃO FAVORECEDORES DO DESENVOLVIMENTO",
                            _ => param.Trim()
                        };


                        foreach (var laudoItem in textoLaudo)
                        {
                            var avisoLaudo = laudoItem.Aviso?.Trim().ToUpper();

                            if (avisoLaudo!.Equals(paramNormalized))
                            {
                                var nota = laudoItem.Aviso;

                                int qualidadeVida = nota switch
                                {
                                    "BemEstarFisico.Bem estar físico" => 25,
                                    "MalEstarFisico.Mal estar físico" => 0,
                                    "AutoEstima.Autoestima e estabilidade emocional" => 25,
                                    "BaixaAutoEstima.Baixa autoestima e dificuldades emocionais" => 0,
                                    "FuncionamentoHarmonico.Funcionamento harmônico familiar" => 25,
                                    "Conflitos.Conflitos no contexto familiar" => 0,
                                    "ContextosFavorecedores.Contextos favorecedores do desenvolvimento" => 25,
                                    "ContextosNaoFavorecedores.Contextos não favorecedores do desenvolvimento" => 0,
                                    _ => 0
                                };

                                scoreQualidadeVida += qualidadeVida;
                            }
                        }
                    }
                }
            }
        }


        var alunoSaudeBucal = laudoSaudeBucal.FirstOrDefault();

        if (alunoSaudeBucal?.SaudeBucal != null)
        {
            var desempenho = desempenhoSaudeBucal.FirstOrDefault();
            if (desempenho != null)
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

        var alunoConsumoAlimentar = laudoConsumoAlimentar.FirstOrDefault();

        if (alunoConsumoAlimentar?.ConsumoAlimentar != null)
        {
            var desempenho = desempenhoConsumoAlimentar.FirstOrDefault();
            if (desempenho != null)
            {
                textoLaudo = _context.TextosLaudos
                    .Where(x =>
                        x.Classificacao!.Equals(desempenho) &&
                        (x.Aviso!.Trim().Equals("HabitosNaoSaudaveis.Hábitos não saudáveis") ||
                         x.Aviso.Trim().Equals("HabitosSatisfatorios.Hábitos satisfatórios") ||
                         x.Aviso.Trim().Equals("BonsHabitosAlimentares.Bons Hábitos alimentares") ||
                         x.Aviso.Trim().Equals("HabitosSaudaveis.Hábitos Saudáveis ")))
                    .ToList();

                var param = laudo.FirstOrDefault()?.ConsumoAlimentar?.Encaminhamento?.Parametro?.Trim();

                var paramNormalized = param switch
                {
                    "HabitosNaoSaudaveis" => "HabitosNaoSaudaveis.Hábitos não saudáveis",
                    "HabitosSatisfatorios" => "HabitosSatisfatorios.Hábitos satisfatórios",
                    "BonsHabitosAlimentares" => "BonsHabitosAlimentares.Bons Hábitos alimentares",
                    "HabitosSaudaveis" => "HabitosSaudaveis.Hábitos Saudáveis ",
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

                            consumoAlimentar = nota switch
                            {
                                "HabitosNaoSaudaveis.Hábitos não saudáveis" => 20,
                                "HabitosSatisfatorios.Hábitos satisfatórios" => 40,
                                "BonsHabitosAlimentares.Bons Hábitos alimentares" => 70,
                                "HabitosSaudaveis.Hábitos Saudáveis " => 100,
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
                ScoreVida = scoreQualidadeVida,
                ScoreVocacional = scoreVocacional,
                ScoreSaudeBucal = saudeBucal,
                ScoreConsumoAlimentar = consumoAlimentar,
                ScoreDna = Round(scoreTalentoEsportivo + scoreSaude + scoreVocacional + saudeBucal + consumoAlimentar + scoreQualidadeVida)
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
