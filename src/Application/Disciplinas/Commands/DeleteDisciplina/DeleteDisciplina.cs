using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Disciplinas.Commands.DeleteDisciplina;
public record DeleteDisciplinaCommand(int Id) : IRequest<bool>;

public class DeleteDisciplinaCommandHandler : IRequestHandler<DeleteDisciplinaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteDisciplinaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteDisciplinaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Disciplinas
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Disciplinas.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
