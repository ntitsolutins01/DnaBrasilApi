using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ArquivosInventarios.Commands.DeleteArquivosInventario;
public record DeleteArquivosInventarioCommand(int Value) : IRequest<bool>;

public class DeleteArquivosInventarioCommandHandler : IRequestHandler<DeleteArquivosInventarioCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteArquivosInventarioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteArquivosInventarioCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ArquivosInventarios
            .FindAsync(new object[] { request.Value }, cancellationToken);

        Guard.Against.NotFound(request.Value, entity);

        _context.ArquivosInventarios.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
