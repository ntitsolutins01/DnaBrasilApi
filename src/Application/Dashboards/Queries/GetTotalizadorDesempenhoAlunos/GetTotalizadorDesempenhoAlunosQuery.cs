using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using MediatR;

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

        alunos = _context.Alunos//.Where(x => x.Id == 37297)//37315 - Feminino 38438
            .AsNoTracking();

        var result = FilterDesempenhoAlunos(alunos, request.SearchFilter!, cancellationToken);

        return result;
    }

    private async Task<TotalizadorDesempenhoDto> FilterDesempenhoAlunos(IQueryable<Aluno> alunos, DashboardDto search,
        CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.FomentoId))
        {
            var id = Convert.ToInt32(search.FomentoId.Split("-")[0]);

            alunos = alunos.Where(u => u.Fomento.Id == id);
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
            
            { "resAbdominal", 0 },
            { "shutlleRun", 0 },
            { "prancha", 0 },
            { "vo2Max", 0 }
        };

        List<TextoLaudo> textoLaudo = new();
        //List<string>? encaminhamento = new List<string>();

        var verificaAlunos = alunos.Select(x => x.Id);

        var laudos = _context.Laudos.Where(x => verificaAlunos.Contains(x.Aluno.Id)).Include(i => i.TalentoEsportivo).Where(x => x.TalentoEsportivo != null)
            .Include(a => a.Aluno)
            .AsNoTracking();

        //var contador = 0;

        foreach (var aluno in laudos)
        {
            if (aluno.TalentoEsportivo == null)
            {
                continue;
            }

            var idade = GetIdade(aluno.Aluno.DtNascimento, DateTime.Now);

            //var modalidades = _context.Modalidades
            //    .Where(x => x.Status == true).ToList();

            foreach (var desempenho in desempenhos)
            {
                textoLaudo = _context.TextosLaudos.Where(x =>
                    x.Status &&
                    x.Classificacao!.Equals(desempenho) &&
                    x.Idade == idade &&
                    (x.Aviso!.Trim() == "Excelente" || x.Aviso!.Trim() == "Muito Bom" || x.Aviso!.Trim() == "Bom") &&
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
                                            if (dictTotalizadorDesempenhoMasculino.ContainsKey("velocidade"))
                                            {
                                                var value = dictTotalizadorDesempenhoMasculino["velocidade"];

                                                value += 1;

                                                dictTotalizadorDesempenhoMasculino["velocidade"] = value;
                                            }

                                            break;
                                        }
                                    default:
                                        {
                                            if (dictTotalizadorDesempenhoFeminino.ContainsKey("velocidade"))
                                            {
                                                var value = dictTotalizadorDesempenhoFeminino["velocidade"];

                                                value += 1;

                                                dictTotalizadorDesempenhoFeminino["velocidade"] = value;
                                            }

                                            break;
                                        }
                                }

                                var valueTotal = dict["velocidade"];

                                valueTotal += 1;

                                dict["velocidade"] = valueTotal;

                                int velocidade = nota switch
                                {
                                    "Muito Bom" => 4,
                                    "Bom" => 3,
                                    "Excelente" => 5,
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
                                            if (dictTotalizadorDesempenhoMasculino.ContainsKey("forcaExplosiva"))
                                            {
                                                var value = dictTotalizadorDesempenhoMasculino["forcaExplosiva"];

                                                value += 1;

                                                dictTotalizadorDesempenhoMasculino["forcaExplosiva"] = value;
                                            }

                                            break;
                                        }
                                    default:
                                        {
                                            if (dictTotalizadorDesempenhoFeminino.ContainsKey("forcaExplosiva"))
                                            {
                                                var value = dictTotalizadorDesempenhoFeminino["forcaExplosiva"];

                                                value += 1;

                                                dictTotalizadorDesempenhoFeminino["forcaExplosiva"] = value;
                                            }

                                            break;
                                        }
                                }

                                var valueTotal = dict["forcaExplosiva"];

                                valueTotal += 1;

                                dict["forcaExplosiva"] = valueTotal;

                                int impulsao = nota switch
                                {
                                    "Muito Bom" => 4,
                                    "Bom" => 3,
                                    "Excelente" => 5,
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
                                            if (dictTotalizadorDesempenhoMasculino.ContainsKey("shutlleRun"))
                                            {
                                                var value = dictTotalizadorDesempenhoMasculino["shutlleRun"];

                                                value += 1;

                                                dictTotalizadorDesempenhoMasculino["shutlleRun"] = value;
                                            }

                                            break;
                                        }
                                    default:
                                        {
                                            if (dictTotalizadorDesempenhoFeminino.ContainsKey("shutlleRun"))
                                            {
                                                var value = dictTotalizadorDesempenhoFeminino["shutlleRun"];

                                                value += 1;

                                                dictTotalizadorDesempenhoFeminino["shutlleRun"] = value;
                                            }

                                            break;
                                        }
                                }

                                var valueTotal = dict["shutlleRun"];

                                valueTotal += 1;

                                dict["shutlleRun"] = valueTotal;

                                int shutlleRun = nota switch
                                {
                                    "Muito Bom" => 4,
                                    "Bom" => 3,
                                    "Excelente" => 5,
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
                                            if (dictTotalizadorDesempenhoMasculino.ContainsKey("flexibilidadeMuscular"))
                                            {
                                                var value = dictTotalizadorDesempenhoMasculino["flexibilidadeMuscular"];

                                                value += 1;

                                                dictTotalizadorDesempenhoMasculino["flexibilidadeMuscular"] = value;
                                            }

                                            break;
                                        }
                                    default:
                                        {
                                            if (dictTotalizadorDesempenhoFeminino.ContainsKey("flexibilidadeMuscular"))
                                            {
                                                var value = dictTotalizadorDesempenhoFeminino["flexibilidadeMuscular"];

                                                value += 1;

                                                dictTotalizadorDesempenhoFeminino["flexibilidadeMuscular"] = value;
                                            }

                                            break;
                                        }
                                }

                                var valueTotal = dict["flexibilidadeMuscular"];

                                valueTotal += 1;

                                dict["flexibilidadeMuscular"] = valueTotal;

                                int flexibilidadeMuscular = nota switch
                                {
                                    "Muito Bom" => 4,
                                    "Bom" => 3,
                                    "Excelente" => 5,
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
                                            if (dictTotalizadorDesempenhoMasculino.ContainsKey("forcaMembrosSup"))
                                            {
                                                var value = dictTotalizadorDesempenhoMasculino["forcaMembrosSup"];

                                                value += 1;

                                                dictTotalizadorDesempenhoMasculino["forcaMembrosSup"] = value;
                                            }

                                            break;
                                        }
                                    default:
                                        {
                                            if (dictTotalizadorDesempenhoFeminino.ContainsKey("forcaMembrosSup"))
                                            {
                                                var value = dictTotalizadorDesempenhoFeminino["forcaMembrosSup"];

                                                value += 1;

                                                dictTotalizadorDesempenhoFeminino["forcaMembrosSup"] = value;
                                            }

                                            break;
                                        }
                                }

                                var valueTotal = dict["forcaMembrosSup"];

                                valueTotal += 1;

                                dict["forcaMembrosSup"] = valueTotal;

                                int forcaMembrosSup = nota switch
                                {
                                    "Muito Bom" => 4,
                                    "Bom" => 3,
                                    "Excelente" => 5,
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
                                            if (dictTotalizadorDesempenhoMasculino.ContainsKey("aptidaoCardio"))
                                            {
                                                var value = dictTotalizadorDesempenhoMasculino["aptidaoCardio"];

                                                value += 1;

                                                dictTotalizadorDesempenhoMasculino["aptidaoCardio"] = value;
                                            }

                                            break;
                                        }
                                    default:
                                        {
                                            if (dictTotalizadorDesempenhoFeminino.ContainsKey("aptidaoCardio"))
                                            {
                                                var value = dictTotalizadorDesempenhoFeminino["aptidaoCardio"];

                                                value += 1;

                                                dictTotalizadorDesempenhoFeminino["aptidaoCardio"] = value;
                                            }

                                            break;
                                        }
                                }

                                var valueTotal = dict["aptidaoCardio"];

                                valueTotal += 1;

                                dict["aptidaoCardio"] = valueTotal;

                                int aptidaoCardio = nota switch
                                {
                                    "Muito Bom" => 4,
                                    "Bom" => 3,
                                    "Excelente" => 5,
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
                                            if (dictTotalizadorDesempenhoMasculino.ContainsKey("prancha"))
                                            {
                                                var value = dictTotalizadorDesempenhoMasculino["prancha"];

                                                value += 1;

                                                dictTotalizadorDesempenhoMasculino["prancha"] = value;
                                            }

                                            break;
                                        }
                                    default:
                                        {
                                            if (dictTotalizadorDesempenhoFeminino.ContainsKey("prancha"))
                                            {
                                                var value = dictTotalizadorDesempenhoFeminino["prancha"];

                                                value += 1;

                                                dictTotalizadorDesempenhoFeminino["prancha"] = value;
                                            }

                                            break;
                                        }
                                }

                                var valueTotal = dict["prancha"];

                                valueTotal += 1;

                                dict["prancha"] = valueTotal;

                                int prancha = nota switch
                                {
                                    "Muito Bom" => 4,
                                    "Bom" => 3,
                                    "Excelente" => 5,
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

            //var q = from x in encaminhamento
            //    group x by x into g
            //    let count = g.Count()
            //    orderby count descending
            //    select new { Value = g.Key, Count = count };

            //var entity = await _context.TalentosEsportivos
            //    .FindAsync(new object[] { aluno.TalentoEsportivo.Id }, cancellationToken);

            //Guard.Against.NotFound(aluno.TalentoEsportivo.Id, entity);
            
            //entity.Encaminhamento = q.FirstOrDefault()!.Value;

            //var result = await _context.SaveChangesAsync(cancellationToken);

            //encaminhamento = new List<string>();
        }
        
        

        var totalMasc = dictTotalizadorDesempenhoMasculino.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percTotalizadorDesempenhoMasculino = dictTotalizadorDesempenhoMasculino.Where(item => totalMasc != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / totalMasc).ToString("F")));

        var totalFem = dictTotalizadorDesempenhoFeminino.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percTotalizadorDesempenhoFeminino = dictTotalizadorDesempenhoFeminino.Where(item => totalFem != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / totalFem).ToString("F")));

        var total = dict.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percDesempenho = dict.Where(item => total != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / total).ToString("F")));

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

            return YearsOld >= 18 ? 99 : YearsOld < 4 ? 4 : YearsOld;
        }
        catch
        {
            return 0;
        }
    }
}

