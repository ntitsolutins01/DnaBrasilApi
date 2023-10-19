using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Commands.CreateAlunoAmbientes;

public record CreateAlunoAmbientesCommand : IRequest<int>
{
}

public class CreateAlunoAmbientesCommandValidator : AbstractValidator<CreateAlunoAmbientesCommand>
{
    public CreateAlunoAmbientesCommandValidator()
    {
    }
}

public class CreateAlunoAmbientesCommandHandler : IRequestHandler<CreateAlunoAmbientesCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAlunoAmbientesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(CreateAlunoAmbientesCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
