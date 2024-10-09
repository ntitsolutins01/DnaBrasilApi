using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using DnaBrasilApi.Domain.Enums;

namespace DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoTalentoEsportivo;

public record UpdateEncaminhamentoTalentoEsportivoCommand(int? AlunoId) : IRequest<bool>;

public class UpdateEncaminhamentoTalentoEsportivoCommandHandler : IRequestHandler<UpdateEncaminhamentoTalentoEsportivoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateEncaminhamentoTalentoEsportivoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateEncaminhamentoTalentoEsportivoCommand request, CancellationToken cancellationToken)
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
            38651, 38685, 38694, 38721, 38742, 38743, 38744, 38746, 38756, 38761, 38765, 38795, 38796, 39795, 39798,
            39809, 39810, 39811, 39812, 39814, 39817, 39818, 39819, 39820, 39821, 39827, 39829, 39830, 39857, 39877,
            39881, 39884, 39890, 39893, 39895, 39898, 39900, 39901, 39907, 39909, 39910, 39912, 39914, 39927, 39928,
            39934, 39935, 39937, 39939, 39968, 39981, 39982, 39993, 40010, 40024, 40029, 40098, 40109, 40114, 40123,
            40138, 40144, 40150, 40151, 40160, 40176, 40178, 40179, 40180, 40181, 40182, 40183, 40184, 40185, 40186,
            40192, 40196, 40199, 40202, 40207, 40210, 40216, 40220, 40226, 40228, 40234, 40238, 40239, 40242, 40253,
            40256, 40271, 40272, 40280, 40288, 40291, 40295, 40299, 40316, 40317, 40319, 40329, 40330, 40335, 40339,
            40355, 40361, 40379, 40380, 40383, 40389, 40393, 40394, 40423, 40424, 40611, 40615, 40724, 40787, 40792,
            40839, 40888, 40940, 41021, 41110, 41111, 41113, 41122, 41124, 41144, 41158, 41185, 41192, 41235, 42206,
            42235, 42240, 42242, 42250, 42251, 42261, 42277, 42284, 42290, 42296, 42390, 42393, 42394, 42395, 42409,
            42417, 42424, 42451, 42453, 42458, 42485, 42486, 42490, 42497, 42502, 42522, 42523, 42525, 42536, 42538,
            42539, 42546, 42547, 42548, 42549, 42550
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

                    var encaminhamentoTalentoEsportivo = encaminhamentos.First(x => x.Nome == nome);

                    entity.EncaminhamentoTexo = q.FirstOrDefault()!.Value;
                    entity.Encaminhamento = encaminhamentoTalentoEsportivo;
                    entity.Imc = GetImc((decimal)talentoEsportivo.Altura!, (decimal)talentoEsportivo.Peso!);

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
