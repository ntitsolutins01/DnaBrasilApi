using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.DocumentosAluno.Commands.DeleteDocumentoAluno;
public record DeleteDocumentoAlunoCommand(int Id) : IRequest<bool>;

public class DeleteDocumentoAlunoCommandHandler : IRequestHandler<DeleteDocumentoAlunoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteDocumentoAlunoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteDocumentoAlunoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.DocumentosAluno
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.DocumentosAluno.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
