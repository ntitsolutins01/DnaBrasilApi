using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using DnaBrasilApi.Domain.Enums;

namespace DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoTalentoEsportivoV1;

public record UpdateEncaminhamentoTalentoEsportivoV1Command : IRequest<bool>
{

}

public class UpdateEncaminhamentoTalentoEsportivoV1CommandHandler : IRequestHandler<UpdateEncaminhamentoTalentoEsportivoV1Command, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateEncaminhamentoTalentoEsportivoV1CommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateEncaminhamentoTalentoEsportivoV1Command request, CancellationToken cancellationToken)
    {
        IQueryable<Aluno> alunos;

        var arr = new int[]
        {
            34906
        };

        alunos = _context.Alunos.Where(x => arr.Contains(x.Id))//37315 - Feminino 38438
            .AsNoTracking();

        var ct = alunos.Count();

        var desempenhos = await _context.TextosLaudos
            .Where(x => x.Status && x.TipoLaudo!.Id == 4)
            .Select(s => s.Classificacao)
            .Distinct()
            .ToListAsync();

        List<TextoLaudo> textoLaudo = new();
        List<string>? encaminhamento = new List<string>();

        var verificaAlunos = alunos.Select(x => x.Id);

        var laudos = _context.Laudos.Where(x => verificaAlunos.Contains(x.Aluno.Id))
            .Include(i => i.TalentoEsportivo)
            //.Where(x => x.TalentoEsportivo == null)
            .Include(a => a.Aluno)
            .AsNoTracking();

        var encaminhamentos = _context.Encaminhamentos
            .Where(x => x.TipoLaudo.Id == (int)EnumTipoLaudo.TalentoEsportivo);

        foreach (var aluno in laudos)
        {
            if (aluno.TalentoEsportivo == null)
            {
                continue;
            }

            var idade = GetIdade(aluno.Aluno.DtNascimento, DateTime.Now);

            var modalidades = _context.Modalidades
                .Where(x => x.Status == true).ToList();

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
                        case "Impuls�o" when
                            aluno.TalentoEsportivo.ImpulsaoHorizontal >= item.PontoInicial &&
                            aluno.TalentoEsportivo.ImpulsaoHorizontal <= item.PontoFinal:
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
                            aluno.TalentoEsportivo.ShuttleRun >= item.PontoInicial &&
                            aluno.TalentoEsportivo.ShuttleRun <= item.PontoFinal:
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
                            aluno.TalentoEsportivo.Flexibilidade >= item.PontoInicial &&
                            aluno.TalentoEsportivo.Flexibilidade <= item.PontoFinal:
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
                        case "Preens�o Manual" when
                            aluno.TalentoEsportivo.PreensaoManual >= item.PontoInicial &&
                            aluno.TalentoEsportivo.PreensaoManual <= item.PontoFinal:
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
                            aluno.TalentoEsportivo.Vo2Max >= item.PontoInicial &&
                            aluno.TalentoEsportivo.Vo2Max <= item.PontoFinal:
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
                            aluno.TalentoEsportivo.Abdominal >= item.PontoInicial &&
                            aluno.TalentoEsportivo.Abdominal <= item.PontoFinal:
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


            var entity = await _context.TalentosEsportivos
                .FindAsync([aluno.TalentoEsportivo.Id], cancellationToken);

            Guard.Against.NotFound(aluno.TalentoEsportivo.Id, entity);

            if (encaminhamento.Count > 0)
            {
                var q = from x in encaminhamento
                        group x by x into g
                        let count = g.Count()
                        orderby count descending
                        select new { Value = g.Key, Count = count };

                entity.EncaminhamentoTexo = q.FirstOrDefault()!.Value;
                var encaminhamentoTalentoEsportivo = encaminhamentos.First(x => x.Nome == q.FirstOrDefault()!.Value);

                entity.Encaminhamento = encaminhamentoTalentoEsportivo;
                entity.Imc = GetImc((decimal)aluno.TalentoEsportivo.Altura!, (decimal)aluno.TalentoEsportivo.Peso!);

                var result = await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                var encaminhamentoTalentoEsportivo = encaminhamentos.First(x => x.Id == 23);

                entity.Encaminhamento = encaminhamentoTalentoEsportivo;
                entity.Imc = GetImc((decimal)aluno.TalentoEsportivo.Altura!, (decimal)aluno.TalentoEsportivo.Peso!);
                entity.EncaminhamentoTexo = "Em Desenvolvimento";

                var result = await _context.SaveChangesAsync(cancellationToken);
            }



            encaminhamento = new List<string>();
        }

        return true;
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

    /// <summary>
    /// Calcula quantidade de anos passdos com base em duas datas, caso encontre qualquer problema retorna 0 
    /// </summary>
    /// <param name="data">Data inicial</param>
    /// <param name="now">Data final ou deixar nula para data atual</param>
    /// <returns>Retorna inteiro com quantiadde de anos</returns>
    private static int GetIdade(DateTime data, DateTime? now = null)
    {
        // Carrega a data do dia para compara��o caso data informada seja nula

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
}
