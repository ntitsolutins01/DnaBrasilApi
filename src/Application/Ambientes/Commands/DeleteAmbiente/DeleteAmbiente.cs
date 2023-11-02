using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Ambientes.Commands.DeleteAmbiente;
public record DeleteAmbienteCommand(int Id) : IRequest;

public class DeleteAmbienteCommandHandler : IRequestHandler<DeleteAmbienteCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteAmbienteCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteAmbienteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Ambientes
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Ambientes.Remove(entity);

        //entity.AddDomainEvent(new AmbienteDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
