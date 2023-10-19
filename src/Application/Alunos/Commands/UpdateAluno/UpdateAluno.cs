using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Commands.UpdateAluno;

public record UpdateAlunoCommand : IRequest<int>
{
}

public class UpdateAlunoCommandValidator : AbstractValidator<UpdateAlunoCommand>
{
    public UpdateAlunoCommandValidator()
    {
    }
}

public class UpdateAlunoCommandHandler : IRequestHandler<UpdateAlunoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateAlunoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(UpdateAlunoCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
