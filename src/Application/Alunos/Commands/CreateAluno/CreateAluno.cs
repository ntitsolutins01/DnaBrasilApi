using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Commands.CreateAluno;

public record CreateAlunoCommand : IRequest<int>
{
}

public class CreateAlunoCommandValidator : AbstractValidator<CreateAlunoCommand>
{
    public CreateAlunoCommandValidator()
    {
    }
}

public class CreateAlunoCommandHandler : IRequestHandler<CreateAlunoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAlunoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAlunoCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
