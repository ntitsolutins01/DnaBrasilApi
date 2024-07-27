using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Modulos.Commands.DeleteModulo;
public record DeleteModuloCommand(int Id) : IRequest<bool>;

public class DeleteModuloCommandHandler : IRequestHandler<DeleteModuloCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteModuloCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteModuloCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Modulos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Modulos.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
