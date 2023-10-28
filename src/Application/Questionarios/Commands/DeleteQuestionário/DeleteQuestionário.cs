using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Questionarios.Commands.DeleteQuestionário;

public record DeleteQuestionárioCommand : IRequest<int>
{
}

public class DeleteQuestionárioCommandValidator : AbstractValidator<DeleteQuestionárioCommand>
{
    public DeleteQuestionárioCommandValidator()
    {
    }
}

public class DeleteQuestionárioCommandHandler : IRequestHandler<DeleteQuestionárioCommand, int>
{
    private readonly IApplicationDbContext _context;

    public DeleteQuestionárioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(DeleteQuestionárioCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
