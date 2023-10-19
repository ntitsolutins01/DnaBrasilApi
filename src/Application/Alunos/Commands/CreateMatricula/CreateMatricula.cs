using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Commands.CreateMatricula;

public record CreateMatriculaCommand : IRequest<int>
{
}

public class CreateMatriculaCommandValidator : AbstractValidator<CreateMatriculaCommand>
{
    public CreateMatriculaCommandValidator()
    {
    }
}

public class CreateMatriculaCommandHandler : IRequestHandler<CreateMatriculaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateMatriculaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(CreateMatriculaCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
