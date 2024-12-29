using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Estruturas.Commands.DeleteEstrutura;
public record DeleteEstruturaCommand(int Id) : IRequest<bool>;

public class DeleteEstruturaCommandHandler : IRequestHandler<DeleteEstruturaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteEstruturaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteEstruturaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Estruturas
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Estruturas.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
