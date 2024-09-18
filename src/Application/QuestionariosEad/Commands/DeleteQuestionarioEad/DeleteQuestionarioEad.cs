using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.QuestionariosEad.Commands.DeleteQuestionarioEad;
public record DeleteQuestionarioEadCommand(int Id) : IRequest<bool>;

public class DeleteQuestionarioEadCommandHandler : IRequestHandler<QuestionariosEad.Commands.DeleteQuestionarioEad.DeleteQuestionarioEadCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteQuestionarioEadCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(QuestionariosEad.Commands.DeleteQuestionarioEad.DeleteQuestionarioEadCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.QuestionariosEad
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.QuestionariosEad.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
