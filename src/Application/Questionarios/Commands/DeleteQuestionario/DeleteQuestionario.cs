using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Questionarios.Commands.DeleteQuestionario;
public record DeleteQuestionarioCommand(int Id) : IRequest<bool>;

public class DeleteQuestionarioCommandHandler : IRequestHandler<Questionarios.Commands.DeleteQuestionario.DeleteQuestionarioCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteQuestionarioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(Questionarios.Commands.DeleteQuestionario.DeleteQuestionarioCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Questionarios
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Questionarios.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
