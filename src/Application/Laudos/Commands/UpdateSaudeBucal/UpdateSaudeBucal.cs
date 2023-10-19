using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Commands.UpdateSaudeBucal;

public record UpdateSaudeBucalCommand : IRequest<int>
{
}

public class UpdateSaudeBucalCommandValidator : AbstractValidator<UpdateSaudeBucalCommand>
{
    public UpdateSaudeBucalCommandValidator()
    {
    }
}

public class UpdateSaudeBucalCommandHandler : IRequestHandler<UpdateSaudeBucalCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateSaudeBucalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(UpdateSaudeBucalCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
