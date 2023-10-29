using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Questionarios.Commands.CreateQuestionário;

public record CreateQuestionárioCommand : IRequest<int>
{
}

public class CreateQuestionárioCommandValidator : AbstractValidator<CreateQuestionárioCommand>
{
    public CreateQuestionárioCommandValidator()
    {
    }
}

public class CreateQuestionárioCommandHandler : IRequestHandler<CreateQuestionárioCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateQuestionárioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(CreateQuestionárioCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
