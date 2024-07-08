using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.FotosEvento.Commands.DeleteFotoEvento;
public record DeleteFotoEventoCommand(int Id) : IRequest<bool>;

public class DeleteFotoEventoCommandHandler : IRequestHandler<DeleteFotoEventoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteFotoEventoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteFotoEventoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.FotosEvento
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.FotosEvento.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
