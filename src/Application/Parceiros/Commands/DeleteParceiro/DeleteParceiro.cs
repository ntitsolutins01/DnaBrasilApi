using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Parceiros.Commands.DeleteParceiro;
public record DeleteParceiroCommand(int Id) : IRequest<bool>;

public class DeleteParceiroCommandHandler : IRequestHandler<DeleteParceiroCommand,bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteParceiroCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteParceiroCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Parceiros
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Parceiros.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
