using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Commands.UpdateAlunoDeficiencias;

public record UpdateAlunoDeficienciasCommand : IRequest<int>
{
}

public class UpdateAlunoDeficienciasCommandValidator : AbstractValidator<UpdateAlunoDeficienciasCommand>
{
    public UpdateAlunoDeficienciasCommandValidator()
    {
    }
}

public class UpdateAlunoDeficienciasCommandHandler : IRequestHandler<UpdateAlunoDeficienciasCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateAlunoDeficienciasCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateAlunoDeficienciasCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
