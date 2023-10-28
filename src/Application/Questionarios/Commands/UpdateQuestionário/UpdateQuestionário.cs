using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Questionarios.Commands.UpdateQuestionário;

public record UpdateQuestionárioCommand : IRequest<int>
{
}

public class UpdateQuestionárioCommandValidator : AbstractValidator<UpdateQuestionárioCommand>
{
    public UpdateQuestionárioCommandValidator()
    {
    }
}

public class UpdateQuestionárioCommandHandler : IRequestHandler<UpdateQuestionárioCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateQuestionárioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateQuestionárioCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
