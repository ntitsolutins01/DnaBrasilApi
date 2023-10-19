using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Commands.CreateSaude;

public record CreateSaudeCommand : IRequest<int>
{
}

public class CreateSaudeCommandValidator : AbstractValidator<CreateSaudeCommand>
{
    public CreateSaudeCommandValidator()
    {
    }
}

public class CreateSaudeCommandHandler : IRequestHandler<CreateSaudeCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateSaudeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateSaudeCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
