using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TiposParcerias.Commands.DeleteTipoParceria;
public record DeleteTipoParceriaCommand(int Id) : IRequest<bool>;

public class DeleteTipoParceriaCommandHandler : IRequestHandler<DeleteTipoParceriaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteTipoParceriaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteTipoParceriaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TiposParcerias
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.TiposParcerias.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
