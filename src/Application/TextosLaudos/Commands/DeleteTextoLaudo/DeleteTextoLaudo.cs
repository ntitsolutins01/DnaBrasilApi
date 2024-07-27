using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TextosLaudos.Commands.DeleteTextoLaudo;
public record DeleteTextoLaudoCommand(int Id) : IRequest<bool>;

public class DeleteTextoLaudoCommandHandler : IRequestHandler<DeleteTextoLaudoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteTextoLaudoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteTextoLaudoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TextosLaudos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.TextosLaudos.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
