using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Commands.CreateAlunoDeficiencias;

public record CreateAlunoDeficienciasCommand : IRequest<int>
{
}

public class CreateAlunoDeficienciasCommandValidator : AbstractValidator<CreateAlunoDeficienciasCommand>
{
    public CreateAlunoDeficienciasCommandValidator()
    {
    }
}

public class CreateAlunoDeficienciasCommandHandler : IRequestHandler<CreateAlunoDeficienciasCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAlunoDeficienciasCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(CreateAlunoDeficienciasCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
