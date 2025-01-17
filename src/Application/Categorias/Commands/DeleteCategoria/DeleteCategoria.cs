using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Categorias.Commands.DeleteCategoria;
public record DeleteCategoriaCommand(int Id) : IRequest<bool>;

public class DeleteCategoriaCommandHandler : IRequestHandler<DeleteCategoriaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteCategoriaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteCategoriaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Categorias
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Categorias.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
