using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.QuestoesEad.Commands.DeleteQuestaoEad;
public record DeleteQuestionarioEadCommand(int Id) : IRequest<bool>;

public class DeleteQuestionarioEadCommandHandler : IRequestHandler<DeleteQuestionarioEadCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteQuestionarioEadCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteQuestionarioEadCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.QuestoesEad
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.QuestoesEad.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
