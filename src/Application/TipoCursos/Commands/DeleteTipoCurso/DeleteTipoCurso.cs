using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TipoCursos.Commands.DeleteTipoCurso;
public record DeleteTipoCursoCommand(int Id) : IRequest<bool>;

public class DeleteTipoCursoCommandHandler : IRequestHandler<DeleteTipoCursoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteTipoCursoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteTipoCursoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TipoCursos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.TipoCursos.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
