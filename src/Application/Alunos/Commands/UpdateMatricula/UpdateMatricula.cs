using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Commands.UpdateMatricula;

public record UpdateMatriculaCommand : IRequest<int>
{
}

public class UpdateMatriculaCommandValidator : AbstractValidator<UpdateMatriculaCommand>
{
    public UpdateMatriculaCommandValidator()
    {
    }
}

public class UpdateMatriculaCommandHandler : IRequestHandler<UpdateMatriculaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateMatriculaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(UpdateMatriculaCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
