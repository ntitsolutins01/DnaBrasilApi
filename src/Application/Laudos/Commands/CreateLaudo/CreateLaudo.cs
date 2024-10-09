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
        Vocacional? vocacional;
        ConsumoAlimentar? consumoAlimentar;
        QualidadeDeVida? qualidadeDeVida;
        SaudeBucal? saudeBucal;
        TalentoEsportivo? talentoEsportivo;

        saude = request.SaudeId != null
            ? await _context.Saudes
                .FindAsync([request.SaudeId!], cancellationToken)
            : null;

        vocacional = request.VocacionalId != null
            ? await _context.Vocacionais
                .FindAsync([request.VocacionalId!], cancellationToken)
            : null;

        consumoAlimentar = request.ConsumoAlimentarId != null
            ? await _context.ConsumoAlimentares
                .FindAsync([request.ConsumoAlimentarId!], cancellationToken)
            : null;

        qualidadeDeVida = request.QualidadeDeVidaId != null
            ? await _context.QualidadeDeVidas
                .FindAsync([request.QualidadeDeVidaId!], cancellationToken)
            : null;

        saudeBucal = request.SaudeBucalId != null
            ? await _context.SaudeBucais
                .FindAsync([request.SaudeBucalId!], cancellationToken)
            : null;

        talentoEsportivo = request.TalentoEsportivoId != null
            ? await _context.TalentosEsportivos
                .FindAsync([request.TalentoEsportivoId!], cancellationToken)
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
}
