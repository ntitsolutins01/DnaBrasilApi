using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Commands.DeleteSaudeBucal;

public record DeleteSaudeBucalCommand : IRequest<int>
{
}

public class DeleteSaudeBucalCommandValidator : AbstractValidator<DeleteSaudeBucalCommand>
{
    public DeleteSaudeBucalCommandValidator()
    {
    }
}

public class DeleteSaudeBucalCommandHandler : IRequestHandler<DeleteSaudeBucalCommand, int>
{
    private readonly IApplicationDbContext _context;

    public DeleteSaudeBucalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(DeleteSaudeBucalCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
