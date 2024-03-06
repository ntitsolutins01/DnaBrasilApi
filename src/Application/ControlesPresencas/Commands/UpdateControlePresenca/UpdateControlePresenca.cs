using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesPresencas.Commands.UpdateControlePresenca;

public record UpdateControlePresencaCommand : IRequest<bool>
{
    public int Id { get; init; }
    public required int AlunoId { get; init; }
    public required string Controle { get; init; }
    public string? Justificativa { get; init; }
    public bool Status { get; init; } = true;
}

public class UpdateControlePresencaCommandHandler : IRequestHandler<UpdateControlePresencaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateControlePresencaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateControlePresencaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ControlesPresencas
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var aluno = await _context.Alunos
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Aluno = aluno!;
        entity.Controle = request.Controle;
        entity.Justificativa = request.Justificativa;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
