using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Commands.CreateSaudeBucal;

public record CreateSaudeBucalCommand : IRequest<int>
{
}

public class CreateSaudeBucalCommandValidator : AbstractValidator<CreateSaudeBucalCommand>
{
    public CreateSaudeBucalCommandValidator()
    {
    }
}

public class CreateSaudeBucalCommandHandler : IRequestHandler<CreateSaudeBucalCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateSaudeBucalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(CreateSaudeBucalCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
