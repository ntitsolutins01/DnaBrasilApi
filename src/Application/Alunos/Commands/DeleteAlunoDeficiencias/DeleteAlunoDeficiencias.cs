using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Commands.DeleteAlunoDeficiencias;

public record DeleteAlunoDeficienciasCommand : IRequest<int>
{
}

public class DeleteAlunoDeficienciasCommandValidator : AbstractValidator<DeleteAlunoDeficienciasCommand>
{
    public DeleteAlunoDeficienciasCommandValidator()
    {
    }
}

public class DeleteAlunoDeficienciasCommandHandler : IRequestHandler<DeleteAlunoDeficienciasCommand, int>
{
    private readonly IApplicationDbContext _context;

    public DeleteAlunoDeficienciasCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(DeleteAlunoDeficienciasCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
