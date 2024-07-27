using System.Globalization;
using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesAcessosAulas.Commands.UpdateControleAcessoAula;

public record UpdateControleAcessoAulaCommand : IRequest <bool>
{
    public required int Id { get; init; }
    public required int AulaId { get; init; }
    public bool IdentificacaoAluno { get; init; } = false;
    public bool AulaRequisito { get; init; }
    public bool PermanenciaAula { get; init; }
    public required string TempoPermanecia { get; init; }
    public required string LiberacaoAula { get; init; }
    public required string DataLiberacao { get; init; }
    public required string DataEncerramento { get; init; }
    public bool Status { get; init; }
}

public class UpdateControleAcessoAulaCommandHandler : IRequestHandler<UpdateControleAcessoAulaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateControleAcessoAulaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateControleAcessoAulaCommand request, CancellationToken cancellationToken)
    {
        var aula = await _context.Aulas
            .FindAsync([request.AulaId], cancellationToken);

        Guard.Against.NotFound(request.AulaId, aula);
        
        var entity = await _context.ControlesAcessosAulas
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Aula = aula;
        entity.LiberacaoAula = request.LiberacaoAula;
        entity.DataLiberacao = DateTime.ParseExact(request.DataLiberacao, "dd/MM/yyyy",
            CultureInfo.CreateSpecificCulture("pt-BR"));
        entity.TempoPermanecia = TimeSpan.Parse(request.TempoPermanecia);
        entity.DataEncerramento = DateTime.ParseExact(request.DataEncerramento!, "dd/MM/yyyy",
            CultureInfo.CreateSpecificCulture("pt-BR"));
        entity.IdentificacaoAluno = request.IdentificacaoAluno;
        entity.AulaRequisito = request.AulaRequisito;
        entity.PermanenciaAula = request.PermanenciaAula;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
