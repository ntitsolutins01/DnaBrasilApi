using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TiposMateriais.Commands.DeleteTipoMaterial;
public record DeleteTipoMaterialCommand(int Id) : IRequest<bool>;

public class DeleteTipoMaterialCommandHandler : IRequestHandler<DeleteTipoMaterialCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteTipoMaterialCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteTipoMaterialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TiposMateriais
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.TiposMateriais.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
