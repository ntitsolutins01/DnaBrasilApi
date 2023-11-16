using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.TipoLaudos.Commands.DeleteTipoLaudos;
public record DeleteTipoLaudoCommand(int Id) : IRequest<bool>;

public class DeleteTipoLaudoCommandHandler : IRequestHandler<DeleteTipoLaudoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteTipoLaudoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteTipoLaudoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TipoLaudos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.TipoLaudos.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
