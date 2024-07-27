using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Usuarios.Commands.DeleteUsuario;

public record DeleteUsuarioCommand(int Id) : IRequest<bool>;

public class DeleteUsuarioCommandHandler : IRequestHandler<DeleteUsuarioCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteUsuarioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Usuarios
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Usuarios.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
