using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Commands.UpdateSaude;

public record UpdateSaudeCommand : IRequest<int>
{
}

public class UpdateSaudeCommandValidator : AbstractValidator<UpdateSaudeCommand>
{
    public UpdateSaudeCommandValidator()
    {
    }
}

public class UpdateSaudeCommandHandler : IRequestHandler<UpdateSaudeCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateSaudeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(UpdateSaudeCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
