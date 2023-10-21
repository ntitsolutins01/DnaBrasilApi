using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Events;

namespace DnaBrasil.Application.Profissionais.Commands.DeleteAluno;
public record DeleteAlunoCommand(int Id) : IRequest;

public class DeleteAlunoCommandHandler : IRequestHandler<DeleteAlunoCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteAlunoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteAlunoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.TodoItems.Remove(entity);

        //entity.AddDomainEvent(new AlunoDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
