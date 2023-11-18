using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Ambientes.Commands.DeleteAmbiente;
public record DeleteAmbienteCommand(int Id) : IRequest<bool>;

public class DeleteAmbienteCommandHandler : IRequestHandler<DeleteAmbienteCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteAmbienteCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteAmbienteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Ambientes
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Ambientes.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
