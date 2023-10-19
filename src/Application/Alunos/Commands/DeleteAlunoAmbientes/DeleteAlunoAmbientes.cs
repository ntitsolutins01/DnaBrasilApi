using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Commands.DeleteAlunoAmbientes;

public record DeleteAlunoAmbientesCommand : IRequest<int>
{
}

public class DeleteAlunoAmbientesCommandValidator : AbstractValidator<DeleteAlunoAmbientesCommand>
{
    public DeleteAlunoAmbientesCommandValidator()
    {
    }
}

public class DeleteAlunoAmbientesCommandHandler : IRequestHandler<DeleteAlunoAmbientesCommand, int>
{
    private readonly IApplicationDbContext _context;

    public DeleteAlunoAmbientesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(DeleteAlunoAmbientesCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
