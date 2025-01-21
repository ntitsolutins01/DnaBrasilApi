using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Materiais.Commands.DeleteMaterial;
public record DeleteMaterialCommand(int Id) : IRequest<bool>;

public class DeleteMaterialCommandHandler : IRequestHandler<DeleteMaterialCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteMaterialCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteMaterialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Materiais
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Materiais.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
