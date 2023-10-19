using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Commands.CreateConsumoAlimentar;

public record CreateConsumoAlimentarCommand : IRequest<int>
{
}

public class CreateConsumoAlimentarCommandValidator : AbstractValidator<CreateConsumoAlimentarCommand>
{
    public CreateConsumoAlimentarCommandValidator()
    {
    }
}

public class CreateConsumoAlimentarCommandHandler : IRequestHandler<CreateConsumoAlimentarCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateConsumoAlimentarCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(CreateConsumoAlimentarCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
