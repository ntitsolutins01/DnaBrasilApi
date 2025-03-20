using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Inventarios.Commands.DeleteInventario;
public record DeleteInventarioCommand(int Id) : IRequest<bool>;

public class DeleteInventarioCommandHandler : IRequestHandler<DeleteInventarioCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteInventarioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteInventarioCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Inventarios
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Inventarios.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
