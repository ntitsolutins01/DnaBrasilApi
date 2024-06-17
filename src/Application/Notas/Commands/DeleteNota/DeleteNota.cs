using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Notas.Commands.DeleteNota;
public record DeleteNotaCommand(int Id) : IRequest<bool>;

public class DeleteNotaCommandHandler : IRequestHandler<DeleteNotaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteNotaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteNotaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Notas
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Notas.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
