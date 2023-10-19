using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Commands.DeleteAluno;

public record DeleteAlunoCommand : IRequest<int>
{
}

public class DeleteAlunoCommandValidator : AbstractValidator<DeleteAlunoCommand>
{
    public DeleteAlunoCommandValidator()
    {
    }
}

public class DeleteAlunoCommandHandler : IRequestHandler<DeleteAlunoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public DeleteAlunoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(DeleteAlunoCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
