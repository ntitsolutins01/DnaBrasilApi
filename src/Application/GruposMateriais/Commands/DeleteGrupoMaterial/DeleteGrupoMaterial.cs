using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.GruposMateriais.Commands.DeleteGrupoMaterial;
public record DeleteGrupoMaterialCommand(int Id) : IRequest<bool>;

public class DeleteGrupoMaterialCommandHandler : IRequestHandler<DeleteGrupoMaterialCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteGrupoMaterialCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteGrupoMaterialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.GruposMateriais
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.GruposMateriais.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
