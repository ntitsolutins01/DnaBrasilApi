using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesPresencas.Commands.DeleteControlePresenca;
public record DeleteControlePresencaCommand(int Id) : IRequest<bool>;

public class DeleteControlePresencaCommandHandler : IRequestHandler<DeleteControlePresencaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteControlePresencaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteControlePresencaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ControlesPresencas
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.ControlesPresencas.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
