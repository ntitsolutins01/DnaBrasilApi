using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Events;

namespace DnaBrasil.Application.Profissionais.Commands.DeleteProfissional;
public record DeleteProfissionalCommand(int Id) : IRequest;

public class DeleteProfissionalCommandHandler : IRequestHandler<DeleteProfissionalCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteProfissionalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteProfissionalCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.TodoItems.Remove(entity);

        //entity.AddDomainEvent(new ProfissionalDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
