using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.AlunosCursos.Commands.CreateAlunoCurso;
public record CreateAlunoCursoCommand : IRequest<int>
{
    public required int AlunoId { get; init; }
    public required int CursoId { get; init; }
}

public class CreateAlunoCursoCommandHandler : IRequestHandler<CreateAlunoCursoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAlunoCursoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAlunoCursoCommand request, CancellationToken cancellationToken)
    {
        var aluno = await _context.Alunos
            .FindAsync([request.AlunoId], cancellationToken);

        Guard.Against.NotFound(request.AlunoId, aluno);

        var curso = await _context.Cursos
            .FindAsync([request.CursoId], cancellationToken);

        Guard.Against.NotFound(request.CursoId, curso);

        var entity = new AlunoCurso
        {
            Aluno = aluno,
            Curso = curso,
            Progresso = 0
        };

        _context.AlunosCursos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
