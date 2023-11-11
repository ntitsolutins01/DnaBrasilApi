using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Contratos.Commands.DeleteContrato;
public record DeleteContratoCommand(int Id) : IRequest;

public class DeleteContratoCommandHandler : IRequestHandler<DeleteContratoCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteContratoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteContratoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Contratos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Contratos.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }

}
