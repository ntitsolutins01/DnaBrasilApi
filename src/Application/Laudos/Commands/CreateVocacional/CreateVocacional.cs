using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Commands.CreateVocacional;

public record CreateVocacionalCommand : IRequest<int>
{
}

public class CreateVocacionalCommandValidator : AbstractValidator<CreateVocacionalCommand>
{
    public CreateVocacionalCommandValidator()
    {
    }
}

public class CreateVocacionalCommandHandler : IRequestHandler<CreateVocacionalCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateVocacionalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(CreateVocacionalCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
