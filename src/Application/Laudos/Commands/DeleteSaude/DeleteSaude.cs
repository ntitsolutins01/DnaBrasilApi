using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Commands.DeleteSaude;

public record DeleteSaudeCommand : IRequest<int>
{
}

public class DeleteSaudeCommandValidator : AbstractValidator<DeleteSaudeCommand>
{
    public DeleteSaudeCommandValidator()
    {
    }
}

public class DeleteSaudeCommandHandler : IRequestHandler<DeleteSaudeCommand, int>
{
    private readonly IApplicationDbContext _context;

    public DeleteSaudeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(DeleteSaudeCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
