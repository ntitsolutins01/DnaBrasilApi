using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Commands.UpdateAluno;

public record UpdateAlunoCommandValidatorCommand : IRequest<object>
{
}

public class UpdateAlunoCommandValidatorCommandValidator : AbstractValidator<UpdateAlunoCommandValidatorCommand>
{
    public UpdateAlunoCommandValidatorCommandValidator()
    {
    }
}

public class UpdateAlunoCommandValidatorCommandHandler : IRequestHandler<UpdateAlunoCommandValidatorCommand, object>
{
    private readonly IApplicationDbContext _context;

    public UpdateAlunoCommandValidatorCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<object> Handle(UpdateAlunoCommandValidatorCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
