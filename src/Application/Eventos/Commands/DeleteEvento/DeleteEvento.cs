using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Eventos.Commands.DeleteEvento;
public record DeleteEventoCommand(int Id) : IRequest<bool>;

public class DeleteEventoCommandHandler : IRequestHandler<DeleteEventoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteEventoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteEventoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Eventos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Eventos.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
