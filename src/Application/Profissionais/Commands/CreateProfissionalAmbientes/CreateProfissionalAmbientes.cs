using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Profissionais.Commands.CreateProfissionalAmbientes;

public record CreateProfissionalAmbientesCommand : IRequest<int>
{
}

public class CreateProfissionalAmbientesCommandValidator : AbstractValidator<CreateProfissionalAmbientesCommand>
{
    public CreateProfissionalAmbientesCommandValidator()
    {
    }
}

public class CreateProfissionalAmbientesCommandHandler : IRequestHandler<CreateProfissionalAmbientesCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateProfissionalAmbientesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(CreateProfissionalAmbientesCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
