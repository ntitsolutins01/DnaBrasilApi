using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Commands.UpdateAlunoCurso;

public record UpdateAlunoCursoCommand : IRequest<bool>
{
    public int AlunoId { get; init; }
    public int CursoId { get; init; }
    public int Progresso { get; init; }

}

public class UpdateAlunoCursoCommandHandler : IRequestHandler<UpdateAlunoCursoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateAlunoCursoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateAlunoCursoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.AlunoCursosCertificados
            .FindAsync(new object[] { request.AlunoId, request.CursoId }, cancellationToken);

        Guard.Against.NotFound($"AlunoCurso ({request.AlunoId}, {request.CursoId})", entity);

        entity.Progresso = request.Progresso;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result >= 1;//true
    }
}
