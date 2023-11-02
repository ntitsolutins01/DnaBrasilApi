using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.TipoLaudos.Commands.DeleteTipoLaudos;
public record DeleteTipoLaudoCommand(int Id) : IRequest;

public class DeleteTipoLaudoCommandHandler : IRequestHandler<DeleteTipoLaudoCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTipoLaudoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteTipoLaudoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TipoLaudos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.TipoLaudos.Remove(entity);

        //entity.AddDomainEvent(new TipoLaudoDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
