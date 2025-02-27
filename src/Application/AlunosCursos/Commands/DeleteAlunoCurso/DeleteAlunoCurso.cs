using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.AlunosCursos.Commands.DeleteAlunoCurso;
public record DeleteAlunoCursoCommand(int Id) : IRequest<bool>;

public class DeleteAlunoCursoCommandHandler : IRequestHandler<DeleteAlunoCursoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteAlunoCursoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteAlunoCursoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.AlunosCursos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.AlunosCursos.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
