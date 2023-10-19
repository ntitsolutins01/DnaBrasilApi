using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Commands.DeleteConsumoAlimentar;

public record DeleteConsumoAlimentarCommand : IRequest<int>
{
}

public class DeleteConsumoAlimentarCommandValidator : AbstractValidator<DeleteConsumoAlimentarCommand>
{
    public DeleteConsumoAlimentarCommandValidator()
    {
    }
}

public class DeleteConsumoAlimentarCommandHandler : IRequestHandler<DeleteConsumoAlimentarCommand, int>
{
    private readonly IApplicationDbContext _context;

    public DeleteConsumoAlimentarCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(DeleteConsumoAlimentarCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
