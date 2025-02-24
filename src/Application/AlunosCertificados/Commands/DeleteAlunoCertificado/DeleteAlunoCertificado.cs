using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.AlunosCertificados.Commands.DeleteAlunoCertificado;
public record DeleteAlunoCertificadoCommand(int Id) : IRequest<bool>;

public class DeleteAlunoCertificadoCommandHandler : IRequestHandler<DeleteAlunoCertificadoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteAlunoCertificadoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteAlunoCertificadoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.AlunosCertificados
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.AlunosCertificados.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
