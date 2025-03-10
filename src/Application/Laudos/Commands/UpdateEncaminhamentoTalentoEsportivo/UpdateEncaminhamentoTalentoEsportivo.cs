using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using DnaBrasilApi.Domain.Enums;

namespace DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoTalentoEsportivo;

public record UpdateEncaminhamentoTalentoEsportivoCommand(int AlunoId) : IRequest<bool>;

public class UpdateEncaminhamentoTalentoEsportivoCommandHandler : IRequestHandler<UpdateEncaminhamentoTalentoEsportivoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateEncaminhamentoTalentoEsportivoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateEncaminhamentoTalentoEsportivoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var desempenhos = await _context.TextosLaudos
            .Where(x => x.Status && x.TipoLaudo!.Id == (int)EnumTipoLaudo.TalentoEsportivo)
            .Select(s => s.Classificacao)
            .Distinct()
            .ToListAsync();

            List<TextoLaudo> textoLaudo = new();
            List<string>? encaminhamento = new List<string>();

            var encaminhamentos = _context.Encaminhamentos
                .Where(x => x.TipoLaudo.Id == (int)EnumTipoLaudo.TalentoEsportivo);

            var arr = new int[]
            {
                34363,45918,43040,41225,45924,45926,45833,33903,45933,43041,45936,45937,33901,42307,45948,45949,45951,45952,45845,42977,45956,40079,45846,40739,34074,42979,42922,43036,40570,45901,40283,34752,45986,40582,45988,45990,45991,45994,43068,42463,40585,33891,33859,46002,46004,43243,42749,41204,45898,34236,46010,34658,46012,34840,45791,46015,34078,46017,46018,34047,34751,46023,46024,39856,46026,46027,46029,46030,33897,33907,46038,46039,46041,46043,34733,46046,46047,45848,42353,46052,34857,46057,46059,46060,46067,46068,46069,40154,46073,46077,46078,46079,46080,34070,42748,35910,46087,42760,42763,46093,46094,46095,40618,34058,41210,41220,46099,42761,34385,46100,34218,40833,46106,46107,46108,46111,46112,40925,34866,40200,46126,46127,34599,34599,46131,40629,43043,46139,46140,34503,46147,41140,46150,41171,46157,41064,34743,34072,46165,46168,46169,46173,41067,46177,34816,46188,45863,39919,46191,46194,34067,46196,45864,46201,46203,46207,46208,46212,46214,46216,33984,34561,45865,42759,42257,46229,46232,33821,46234,46237,46238,42462,41199,46243,40924,46247,46252,46253,46255,42560,46267,42845,46269,34875,45869,45870,46273,46274,41216,45871,33808,46290,34220,46292,46293,34406,46301,46305,41213,45794,45794,46310,42232,42232,46314,46317,45872,40191,40762,46325,46326,46328,46329,45815,40153,46335,46336,34103,42464,46344,42752,34073,46351,43033,42846,43030,43034,46366,43032,46369,43202,46376,46379,46382,40148,42900,46389,46391,45879,46813,40156,34811,46397,45884,45884,46400,34557,34076,46403,46405,46406,46409,46410,46411,46413,46414,46416,43055,46420,46421,46422,46423,46428,45888,40899,46433,46435,46437,45020,33850,46444,39936,40600,46454,46455,41187,46461,46462,46463,46472,46787,46475,46479,46484,41164,33873,34397,46500,46505,34106,33868,46517,40460,42466,46523,46525,40936,33847,46534,46542,46543,46544,42844,46550,46551,45799,42300,46556,42758,46558,34600,46788,46788,46565,46568,46570,46577,46580,46581,46587,42998,34227,46594,46596,40567,46603,40807,33878,46608,46612,46614,46615,41137,46622,46624,41194,33852,34274,46636,46639,46642,46645,45827,43212,46652,40601,42860,46659,43000,46668,46670,34738,46673,46674,46675,46681,46684,43111,46795,46708,34825,42862,46711,34223,46720,43136,40579,33888,33888,42584,42584,46734,34086,34087,34655,46757,40482,46761,46763,46773,46776

            };

            foreach (int a in arr)
            {
                var listTalentoEsportivo = _context.TalentosEsportivos
                .Include(i => i.Aluno)
                .Where(x => x.Aluno!.Id == a)//arr.Contains(x.Aluno!.Id))
                .AsNoTracking();
                //

                if (request.AlunoId != 0)
                {
                    listTalentoEsportivo = listTalentoEsportivo.Where(x => x.Aluno!.Id == request.AlunoId);
                }

                foreach (var talentoEsportivo in listTalentoEsportivo)
                {
                    var idade = GetIdade(talentoEsportivo.Aluno!.DtNascimento, DateTime.Now);

                    var modalidades = _context.Modalidades
                        .Where(x => x.Status == true).ToList();

                    foreach (var desempenho in desempenhos)
                    {
                        textoLaudo = _context.TextosLaudos.Where(x =>
                            x.Status &&
                            x.Classificacao!.Equals(desempenho) &&
                            x.Idade == idade &&
                            (x.Aviso!.Trim() == "Excelente" || x.Aviso!.Trim() == "Muito Bom" || x.Aviso!.Trim() == "Bom") &&
                            x.Sexo == (idade == 99 ? "G" : talentoEsportivo.Aluno.Sexo)).ToList();

                        foreach (var item in textoLaudo)
                        {
                            switch (item.Classificacao)
                            {
                                case "Velocidade" when
                                    talentoEsportivo.Velocidade >= item.PontoInicial &&
                                    talentoEsportivo.Velocidade <= item.PontoFinal:
                                    {
                                        var nota = item.Aviso;

                                        int velocidade = nota switch
                                        {
                                            "Muito Bom" => 4,
                                            "Bom" => 3,
                                            "Excelente" => 5,
                                            _ => 0
                                        };

                                        encaminhamento!.AddRange(modalidades
                                            .Where(x => velocidade >= x.VinteMetrosIni && velocidade <= x.VinteMetrosFim)
                                            .Select(s => s.Nome).ToList()!);
                                        break;
                                    }
                                case "Impulsão" when
                                    talentoEsportivo.ImpulsaoHorizontal >= item.PontoInicial &&
                                    talentoEsportivo.ImpulsaoHorizontal <= item.PontoFinal:
                                    {
                                        var nota = item.Aviso;

                                        int impulsao = nota switch
                                        {
                                            "Muito Bom" => 4,
                                            "Bom" => 3,
                                            "Excelente" => 5,
                                            _ => 0
                                        };

                                        encaminhamento!.AddRange(modalidades
                                            .Where(x => impulsao >= x.ImpulsaoIni && impulsao <= x.ImpulsaoFim)
                                            .Select(s => s.Nome).ToList()!);
                                        break;
                                    }
                                case "Agilidade ou Shuttle run" when
                                    talentoEsportivo.ShuttleRun >= item.PontoInicial &&
                                    talentoEsportivo.ShuttleRun <= item.PontoFinal:
                                    {
                                        var nota = item.Aviso;

                                        int shutlleRun = nota switch
                                        {
                                            "Muito Bom" => 4,
                                            "Bom" => 3,
                                            "Excelente" => 5,
                                            _ => 0
                                        };

                                        encaminhamento!.AddRange(modalidades
                                            .Where(x => shutlleRun >= x.ShutlleRunIni && shutlleRun <= x.ShutlleRunFim)
                                            .Select(s => s.Nome).ToList()!);
                                        break;
                                    }
                                case "Flexibilidade" when
                                    talentoEsportivo.Flexibilidade >= item.PontoInicial &&
                                    talentoEsportivo.Flexibilidade <= item.PontoFinal:
                                    {
                                        var nota = item.Aviso;

                                        int flexibilidadeMuscular = nota switch
                                        {
                                            "Muito Bom" => 4,
                                            "Bom" => 3,
                                            "Excelente" => 5,
                                            _ => 0
                                        };

                                        encaminhamento!.AddRange(modalidades
                                            .Where(x => flexibilidadeMuscular >= x.FlexibilidadeIni &&
                                                        flexibilidadeMuscular <= x.FlexibilidadeFim)
                                        .Select(s => s.Nome).ToList()!);
                                        break;
                                    }
                                case "Preensão Manual" when
                                    talentoEsportivo.PreensaoManual >= item.PontoInicial &&
                                    talentoEsportivo.PreensaoManual <= item.PontoFinal:
                                    {
                                        var nota = item.Aviso;

                                        int forcaMembrosSup = nota switch
                                        {
                                            "Muito Bom" => 4,
                                            "Bom" => 3,
                                            "Excelente" => 5,
                                            _ => 0
                                        };

                                        encaminhamento!.AddRange(modalidades
                                            .Where(x => forcaMembrosSup >= x.PreensaoManualIni &&
                                                        forcaMembrosSup <= x.PreensaoManualFim)
                                            .Select(s => s.Nome).ToList()!);
                                        break;
                                    }
                                case "Vo2 Max" when
                                    talentoEsportivo.Vo2Max >= item.PontoInicial &&
                                    talentoEsportivo.Vo2Max <= item.PontoFinal:
                                    {
                                        var nota = item.Aviso;

                                        int aptidaoCardio = nota switch
                                        {
                                            "Muito Bom" => 4,
                                            "Bom" => 3,
                                            "Excelente" => 5,
                                            _ => 0
                                        };

                                        encaminhamento!.AddRange(modalidades
                                            .Where(x => aptidaoCardio >= x.Vo2MaxIni && aptidaoCardio <= x.Vo2MaxFim)
                                            .Select(s => s.Nome).ToList()!);
                                        break;
                                    }
                                case "Prancha (ABD)" when
                                    talentoEsportivo.Abdominal >= item.PontoInicial &&
                                    talentoEsportivo.Abdominal <= item.PontoFinal:
                                    {
                                        var nota = item.Aviso;

                                        int prancha = nota switch
                                        {
                                            "Muito Bom" => 4,
                                            "Bom" => 3,
                                            "Excelente" => 5,
                                            _ => 0
                                        };

                                        encaminhamento!.AddRange(modalidades
                                            .Where(x => prancha >= x.AbdominalPranchaIni && prancha <= x.AbdominalPranchaFim)
                                            .Select(s => s.Nome).ToList()!);
                                        break;
                                    }
                            }
                        }
                    }

                    var entity = _context.TalentosEsportivos
                        .Include(i => i.Encaminhamento)
                        .Where(x => x.Id == talentoEsportivo.Id)
                        .FirstOrDefault();

                    Guard.Against.NotFound(talentoEsportivo.Id, entity);

                    if (encaminhamento.Count > 0)
                    {
                        var q = from x in encaminhamento
                                group x by x into g
                                let count = g.Count()
                                orderby count descending
                                select new { Value = g.Key, Count = count };

                        var nome = q.FirstOrDefault()!.Value;

                        var encaminhamentoTalentoEsportivo = encaminhamentos.First(x => x.Nome.Contains(nome));

                        entity.EncaminhamentoTexo = q.FirstOrDefault()!.Value;
                        entity.Encaminhamento = encaminhamentoTalentoEsportivo;
                        entity.Imc = GetImc((decimal)talentoEsportivo.Altura!, (decimal)talentoEsportivo.Peso!);

                        await _context.SaveChangesAsync(cancellationToken);

                        var modalidade = _context.Modalidades
                            .FirstOrDefault(x => x.Nome!.Contains(entity.EncaminhamentoTexo));

                        var laudo = _context.Laudos
                            .FirstOrDefault(l => l.TalentoEsportivo != null && l.TalentoEsportivo.Id == entity.Id);

                        if (laudo != null)
                        {
                            laudo.Modalidade = modalidade;
                        }

                        await _context.SaveChangesAsync(cancellationToken);
                    }
                    else
                    {
                        var encaminhamentoTalentoEsportivo = encaminhamentos.First(x => x.Id == 23);

                        entity.EncaminhamentoTexo = "Em Desenvolvimento";
                        entity.Encaminhamento = encaminhamentoTalentoEsportivo;
                        entity.Imc = GetImc((decimal)talentoEsportivo.Altura!, (decimal)talentoEsportivo.Peso!);

                        await _context.SaveChangesAsync(cancellationToken);
                    }

                    encaminhamento = new List<string>();
                }
            }

            return true;
        }
        catch(Exception ex)
        {
            Console.Write(ex.Message);
            return false;
        }
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

        now = now == null ? DateTime.Now : now;

        try
        {
            int YearsOld = now.Value.Year - data.Year;

            if (now.Value.Month < data.Month || now.Value.Month == data.Month && now.Value.Day < data.Day)
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

    /// <summary>
    /// Calcula Imc
    /// </summary>
    private static decimal GetImc(decimal altura, decimal massa)
    {

        try
        {
            double alturaMetros = (double)(altura * (decimal?)0.01)!;
            var imc = Convert.ToDecimal(((double)massa / Math.Pow(alturaMetros, 2)).ToString("F"));

            return imc;
        }
        catch
        {
            return 0;
        }
    }
}
