using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Profissionais.Commands.DeleteProfissional;

public record DeleteProfissionalCommand : IRequest<int>
{
}

public class DeleteProfissionalCommandValidator : AbstractValidator<DeleteProfissionalCommand>
{
    public DeleteProfissionalCommandValidator()
    {
    }
}

public class DeleteProfissionalCommandHandler : IRequestHandler<DeleteProfissionalCommand, int>
{
    private readonly IApplicationDbContext _context;

    public DeleteProfissionalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(DeleteProfissionalCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
