using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Commands.CreateLaudo;

public record CreateLaudoCommand : IRequest<int>
{
    public required int AlunoId { get; init; }
    public int? SaudeId { get; init; }
    public int? VocacionalId { get; init; }
    public int? ConsumoAlimentarId { get; init; }
    public int? QualidadeDeVidaId { get; init; }
    public int? SaudeBucalId { get; init; }
    public int? TalentoEsportivoId { get; init; }
    public string? StatusLaudo { get; set; }
}

public class CreateLaudoCommandHandler : IRequestHandler<CreateLaudoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateLaudoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateLaudoCommand request, CancellationToken cancellationToken)
    {
        var aluno = await _context.Alunos.FindAsync(new object[] { request.AlunoId }, cancellationToken);

        Guard.Against.NotFound((int)request.AlunoId, aluno);

        Saude? saude;
        Vocacional? vocacional = null;
        ConsumoAlimentar? consumoAlimentar;
        QualidadeDeVida? qualidadeDeVida = null;
        SaudeBucal? saudeBucal;
        TalentoEsportivo? talentoEsportivo;

        var idade = GetIdade(aluno.DtNascimento, DateTime.Now);

        saude = request.SaudeId != null
            ? await _context.Saudes
                .FindAsync([request.SaudeId!], cancellationToken)
            : null;

        talentoEsportivo = request.TalentoEsportivoId != null
            ? await _context.TalentosEsportivos
                .FindAsync([request.TalentoEsportivoId!], cancellationToken)
            : null;

        consumoAlimentar = request.ConsumoAlimentarId != null
            ? await _context.ConsumoAlimentares
                .FindAsync([request.ConsumoAlimentarId!], cancellationToken)
            : null;

        saudeBucal = request.SaudeBucalId != null
            ? await _context.SaudeBucais
                .FindAsync([request.SaudeBucalId!], cancellationToken)
            : null;

        switch (idade)
        {
            case >= 14:
                qualidadeDeVida = request.QualidadeDeVidaId != null
                    ? await _context.QualidadeDeVidas
                        .FindAsync([request.QualidadeDeVidaId!], cancellationToken)
                    : null;

                vocacional = request.VocacionalId != null
                    ? await _context.Vocacionais
                        .FindAsync([request.VocacionalId!], cancellationToken)
                    : null;


                request.StatusLaudo = qualidadeDeVida != null
                                      &&
                                      vocacional != null
                                      &&
                                      saude != null
                                      &&
                                      consumoAlimentar != null
                                      &&
                                      saudeBucal != null
                                      &&
                                      talentoEsportivo != null
                    ? "F"
                    : "A";
                break;
            case >= 12:
                qualidadeDeVida = request.QualidadeDeVidaId != null
                    ? await _context.QualidadeDeVidas
                        .FindAsync([request.QualidadeDeVidaId!], cancellationToken)
                    : null;


                request.StatusLaudo = qualidadeDeVida != null
                                      &&
                                      saude != null
                                      &&
                                      consumoAlimentar != null
                                      &&
                                      saudeBucal != null
                                      &&
                                      talentoEsportivo != null
                    ? "F"
                    : "A";
                break;
        }

        request.StatusLaudo = saude != null
                              &&
                              consumoAlimentar != null
                              &&
                              saudeBucal != null
                              &&
                              talentoEsportivo != null
            ? "F"
            : "A";

        var entity = new Laudo()
        {
            Aluno = aluno,
            Saude = saude,
            Vocacional = vocacional,
            ConsumoAlimentar = consumoAlimentar,
            QualidadeDeVida = qualidadeDeVida,
            SaudeBucal = saudeBucal,
            TalentoEsportivo = talentoEsportivo,
            StatusLaudo = request.StatusLaudo
        };

        _context.Laudos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
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

            return YearsOld > 18 ? 99 : YearsOld < 4 ? 4 : YearsOld;
        }
        catch
        {
            return 0;
        }
    }
}
