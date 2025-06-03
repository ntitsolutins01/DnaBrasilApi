using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Commands.UpdateModalidadeLaudo;

public record UpdateModalidadeLaudoCommand(int AlunoId) : IRequest<bool>;

public class UpdateModalidadeLaudoCommandHandler : IRequestHandler<UpdateModalidadeLaudoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateModalidadeLaudoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateModalidadeLaudoCommand request, CancellationToken cancellationToken)
    {
        try
        {

            var laudos = await _context.Laudos
                .Include(i => i.Modalidade)
                .Include(i => i.TalentoEsportivo!.Encaminhamento)
                .Where(x => x.Modalidade == null && x.TalentoEsportivo != null)
                .ToListAsync();


            foreach (Laudo item in laudos)
            {
                var modalidade = _context.Modalidades
                    .FirstOrDefault(x =>
                        item.TalentoEsportivo != null && item.TalentoEsportivo.Encaminhamento != null &&
                        x.Nome!.Contains(item.TalentoEsportivo.Encaminhamento.Nome));

                var laudo = _context.Laudos
                    .FirstOrDefault(l =>
                        l.TalentoEsportivo != null && item.TalentoEsportivo != null &&
                        l.TalentoEsportivo.Id == item.TalentoEsportivo.Id);

                if (laudo != null)
                {
                    laudo.Modalidade = modalidade;
                }

                await _context.SaveChangesAsync(cancellationToken);
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
