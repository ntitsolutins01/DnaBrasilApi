using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.GuardClauses;

namespace DnaBrasilApi.Application.Cursos.Commands.DeleteCurso;
public record DeleteCursoCommand(int Id) : IRequest<bool>;

public class DeleteCursoCommandHandler : IRequestHandler<DeleteCursoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteCursoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteCursoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Cursos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var possuiModulosEad = _context.ModulosEad.Any(x => x.Curso != null && x.Curso.Id == request.Id);

        Guard.Against.PossuiModulosEad(possuiModulosEad);

        _context.Cursos.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
