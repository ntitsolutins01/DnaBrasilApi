using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Commands.DeleteVocacional;

public record DeleteVocacionalCommand : IRequest<int>
{
}

public class DeleteVocacionalCommandValidator : AbstractValidator<DeleteVocacionalCommand>
{
    public DeleteVocacionalCommandValidator()
    {
    }
}

public class DeleteVocacionalCommandHandler : IRequestHandler<DeleteVocacionalCommand, int>
{
    private readonly IApplicationDbContext _context;

    public DeleteVocacionalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(DeleteVocacionalCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
