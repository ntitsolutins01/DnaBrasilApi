using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Commands.CreateAluno;

public record CreateAlunoCommandValidatorCommand : IRequest<int>
{
}

public class CreateAlunoCommandValidatorCommandValidator : AbstractValidator<CreateAlunoCommandValidatorCommand>
{
    public CreateAlunoCommandValidatorCommandValidator()
    {
    }
}

public class CreateAlunoCommandValidatorCommandHandler : IRequestHandler<CreateAlunoCommandValidatorCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAlunoCommandValidatorCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAlunoCommandValidatorCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
