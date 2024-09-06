using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesMateriais.Commands.DeleteControleMaterial;
public record DeleteControleMaterialCommand(int Id) : IRequest<bool>;

public class DeleteControleMaterialCommandHandler : IRequestHandler<DeleteControleMaterialCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteControleMaterialCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteControleMaterialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ControlesMateriais
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.ControlesMateriais.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
