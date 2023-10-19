using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Commands.UpdateConsumoAlimentar;

public record UpdateConsumoAlimentarCommand : IRequest<int>
{
}

public class UpdateConsumoAlimentarCommandValidator : AbstractValidator<UpdateConsumoAlimentarCommand>
{
    public UpdateConsumoAlimentarCommandValidator()
    {
    }
}

public class UpdateConsumoAlimentarCommandHandler : IRequestHandler<UpdateConsumoAlimentarCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateConsumoAlimentarCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateConsumoAlimentarCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
