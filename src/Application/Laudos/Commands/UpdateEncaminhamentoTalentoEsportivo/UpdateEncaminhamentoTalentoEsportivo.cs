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
                45916,
                34363,
                34729,
                45921,
                42465,
                34258,
                45926,
                41190,
                40650,
                45928,
                40775,
                45929,
                33903,
                34059,
                40647,
                45933,
                34100,
                45936,
                33801,
                33901,
                45938,
                42307,
                34297,
                45946,
                45947,
                45948,
                40127,
                40520,
                45951,
                41066,
                45952,
                34832,
                34080,
                40577,
                42977,
                45956,
                40731,
                45958,
                40633,
                40079,
                34688,
                45962,
                34074,
                42459,
                45966,
                34862,
                45968,
                42979,
                34359,
                43036,
                40634,
                40570,
                40773,
                42537,
                45901,
                45979,
                40568,
                40283,
                45847,
                34752,
                40889,
                45991,
                41226,
                42750,
                45994,
                42463,
                45999,
                39941,
                33891,
                33859,
                46002,
                33809,
                33916,
                46004,
                43243,
                42749,
                41204,
                45898,
                34236,
                46012,
                40557,
                45791,
                34078,
                33860,
                46017,
                33815,
                40921,
                34751,
                34819,
                46028,
                46029,
                46030,
                33897,
                40812,
                34425,
                40581,
                46032,
                46033,
                46035,
                33907,
                34216,
                34820,
                40638,
                46040,
                34733,
                34071,
                46046,
                33857,
                46047,
                45848,
                42353,
                41081,
                42350,
                40842,
                34857,
                46055,
                41105,
                46057,
                41026,
                46060,
                34405,
                34222,
                46064,
                46065,
                40784,
                46067,
                46069,
                40154,
                46073,
                41069,
                46077,
                33870,
                33829,
                46080,
                34070,
                34817,
                33896,
                46086,
                34854,
                40620,
                46087,
                42589,
                42760,
                34560,
                46093,
                40618,
                40685,
                34555,
                46099,
                42761,
                34385,
                46100,
                34218,
                40758,
                40833,
                46106,
                34248,
                46108,
                46110,
                46111,
                46112,
                34096,
                34247,
                40925,
                34238,
                46120,
                41228,
                34599,
                46131,
                40629,
                46141,
                34503,
                33983,
                46145,
                40562,
                46150,
                34357,
                33902,
                46153,
                34633,
                46155,
                40722,
                34105,
                41064,
                40848,
                46159,
                42211,
                34743,
                40560,
                34068,
                34072,
                34061,
                33865,
                41149,
                34601,
                41067,
                46177,
                33872,
                41103,
                34053,
                34108,
                34261,
                34035,
                34816,
                46186,
                33921,
                34064,
                46193,
                42317,
                46194,
                34067,
                46195,
                46196,
                34373,
                46198,
                41209,
                34644,
                40627,
                46200,
                41087,
                34362,
                46201,
                34804,
                46204,
                34262,
                46206,
                46211,
                41084,
                34732,
                45865,
                42257,
                33805,
                46224,
                46225,
                34065,
                46226,
                42347,
                46228,
                46229,
                46230,
                46231,
                41085,
                33824,
                34063,
                40772,
                33830,
                46237,
                46238,
                45866,
                34033,
                46243,
                40924,
                33879,
                46246,
                46247,
                46251,
                46252,
                40621,
                46253,
                46254,
                46256,
                40776,
                34083,
                41027,
                34796,
                40938,
                40907,
                46267,
                40883,
                34875,
                45870,
                34081,
                41150,
                40111,
                46277,
                41216,
                46279,
                41152,
                40727,
                46285,
                34730,
                33808,
                34620,
                46290,
                46293,
                34293,
                41036,
                34613,
                46298,
                40474,
                45907,
                40532,
                34368,
                46303,
                34618,
                40550,
                46305,
                41213,
                45794,
                34091,
                46310,
                40898,
                46313,
                33862,
                46316,
                40762,
                33804,
                46322,
                40490,
                46324,
                40741,
                46325,
                41033,
                40005,
                46328,
                46329,
                34057,
                46330,
                46331,
                40782,
                40599,
                40825,
                34103,
                42975,
                46340,
                42464,
                46344,
                33864,
                46346,
                42752,
                34073,
                46351,
                42846,
                40644,
                42398,
                46359,
                40754,
                40755,
                34066,
                43034,
                46366,
                33914,
                43032,
                40763,
                33927,
                40808,
                40710,
                43202,
                34215,
                46376,
                34768,
                42754,
                33895,
                46382,
                42900,
                34795,
                46389,
                40565,
                46391,
                34848,
                34811,
                33920,
                41088,
                33928,
                46400,
                33858,
                41086,
                34557,
                34076,
                34867,
                41201,
                46405,
                46406,
                34744,
                46409,
                33851,
                46410,
                42811,
                40761,
                34077,
                40708,
                40756,
                41176,
                34834,
                41157,
                46419,
                46420,
                41202,
                46421,
                46423,
                33848,
                41089,
                34259,
                41165,
                46433,
                46437,
                45020,
                40903,
                33850,
                41022,
                34602,
                33849,
                40519,
                39936,
                46449,
                46450,
                40600,
                46454,
                46456,
                40728,
                46457,
                40918,
                46462,
                40901,
                33877,
                34404,
                46467,
                40625,
                40681,
                46472,
                45890,
                46787,
                34036,
                33915,
                34060,
                46478,
                42217,
                46479,
                33886,
                46484,
                45894,
                40769,
                40765,
                33873,
                34397,
                41189,
                41188,
                46490,
                46492,
                41169,
                46493,
                40591,
                41203,
                42421,
                46500,
                46501,
                46502,
                34130,
                34257,
                34588,
                46505,
                40459,
                41062,
                42467,
                33868,
                40574,
                41143,
                33925,
                40129,
                34680,
                35557,
                40537,
                35896,
                40991,
                40544,
                40993,
                35524,
                35468,
                35483,
                40538,
                38785,
                35574,
                35532,
                35477,
                35801,
                41109,
                40989,
                35446,
                35427,
                35495,
                35458,
                35729,
                35319,
                35597,
                40481,
                35913,
                40995,
                35424,
                35482,
                35765,
                35912,
                35906,
                35651,
                40545,
                42393,
                34998,
                35471,
                35683,
                40486,
                40468,
                35576,
                35516,
                35447,
                40999,
                35467,
                35693,
                42546,
                35750,
                35686,
                35504,
                35874,
                35742,
                35641,
                35555,
                35394,
                35418,
                35530,
                40503,
                35672,
                35670,
                41091,
                35652,
                35465,
                35497,
                40551,
                35591,
                42497,
                41004,
                35595,
                35914,
                35811,
                40997,
                41090,
                35662,
                41021,
                40960,
                35479,
                35531,
                35349,
                39787,
                35888,
                35605,
                35606,
                40968,
                35921,
                35481,
                41003,
                35862,
                35589,
                35462,
                35602,
                35543,
                35350,
                35596,
                35598,
                35650,
                40552,
                35918,
                35916,
                40539,
                40508,
                41099,
                35562,
                35653,
                40536,
                35792,
                35541,
                35472,
                41007,
                35897,
                35547,
                40492,
                41096,
                35644,
                35461,
                35066,
                34973,
                40998,
                35443,
                40546,
                39791,
                35831,
                41042,
                40970,
                35180,
                40242,
                40913,
                40462,
                42451,
                35486,
                40495,
                35892,
                41010,
                40961,
                35442,
                34903,
                35500,
                40543,
                41001,
                40969,
                40971,
                35894,
                40522,
                41011,
                34906,
                40972,
                40606,
                41000,
                41006,
                40465,
                40535,
                41002,
                40540,
                35359,
                40996,
                41009,
                41005,
                40973,
                35324,
                40963,
                40965,
                41008,
                40549,
                35439,
                40967,
                40964,
                40496,
                40521,
                40485,
                40523,
                35379,
                40986,
                40483,
                40988,
                35380,
                40974,
                35441,
                40994,
                40966,
                40528,
                40467,
                40437,
                40573,
                40637,
                35505,
                40506,
                35449,
                35451,
                41012,
                40547,
                40548,
                40980,
                42548,
                40979,
                35420,
                40978,
                40985,
                40977,
                40992,
                40984,
                40981,
                40987,
                40983,
                40975,
                40990,
                40982,
                40976,
                40466,
                40962,
                40489,
                40461,
                40530,
                35360,
                40531,
                40529,
                40524,
                40527,
                40604,
                35512,
                42502,
                40603,
                41100,
                41098,
                35692,
                40526,
                41097
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
        catch (Exception ex)
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
