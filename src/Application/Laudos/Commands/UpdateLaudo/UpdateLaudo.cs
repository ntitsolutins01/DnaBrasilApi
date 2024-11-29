using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Commands.UpdateLaudo;

public record UpdateLaudoCommand : IRequest<bool>
{
    public int Id { get; init; }
    public required int AlunoId { get; init; }
    public int? SaudeId { get; init; }
    public int? VocacionalId { get; init; }
    public int? ConsumoAlimentarId { get; init; }
    public int? QualidadeDeVidaId { get; init; }
    public int? SaudeBucalId { get; init; }
    public int? TalentoEsportivoId { get; init; }
    public string? StatusLaudo { get; set; }
}

public class UpdateLaudoCommandHandler : IRequestHandler<UpdateLaudoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateLaudoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateLaudoCommand request, CancellationToken cancellationToken)
    {

        var entity = await _context.Laudos
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

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

        entity.Aluno = aluno;
        entity.Saude = saude;
        entity.Vocacional = vocacional;
        entity.ConsumoAlimentar = consumoAlimentar;
        entity.QualidadeDeVida = qualidadeDeVida;
        entity.SaudeBucal = saudeBucal;
        entity.TalentoEsportivo = talentoEsportivo;
        entity.StatusLaudo = request.StatusLaudo;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
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
