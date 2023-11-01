using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Questionarios.Commands.DeleteQuestionario;
public record DeleteQuestionarioCommand(int Id) : IRequest;

public class DeleteQuestionarioCommandHandler : IRequestHandler<DeleteQuestionarioCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteQuestionarioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteQuestionarioCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Questionarios
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Questionarios.Remove(entity);

        //entity.AddDomainEvent(new QuestionarioDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
