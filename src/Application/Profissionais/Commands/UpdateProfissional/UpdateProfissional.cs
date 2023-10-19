using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Profissionais.Commands.UpdateProfissional;

public record UpdateProfissionalCommand : IRequest<int>
{
}

public class UpdateProfissionalCommandValidator : AbstractValidator<UpdateProfissionalCommand>
{
    public UpdateProfissionalCommandValidator()
    {
    }
}

public class UpdateProfissionalCommandHandler : IRequestHandler<UpdateProfissionalCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateProfissionalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(UpdateProfissionalCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
