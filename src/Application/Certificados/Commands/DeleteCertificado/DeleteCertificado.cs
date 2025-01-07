using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Certificados.Commands.DeleteCertificado;
public record DeleteCertificadoCommand(int Id) : IRequest<bool>;

public class DeleteCertificadoCommandHandler : IRequestHandler<DeleteCertificadoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteCertificadoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteCertificadoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Certificados
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Certificados.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
