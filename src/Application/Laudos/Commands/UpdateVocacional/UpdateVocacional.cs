using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Commands.UpdateVocacional;

public record UpdateVocacionalCommand : IRequest<int>
{
}

public class UpdateVocacionalCommandValidator : AbstractValidator<UpdateVocacionalCommand>
{
    public UpdateVocacionalCommandValidator()
    {
    }
}

public class UpdateVocacionalCommandHandler : IRequestHandler<UpdateVocacionalCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateVocacionalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(UpdateVocacionalCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
