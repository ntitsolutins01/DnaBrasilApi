using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Commands.UpdateAlunoAmbientes;

public record UpdateAlunoAmbientesCommand : IRequest<int>
{
}

public class UpdateAlunoAmbientesCommandValidator : AbstractValidator<UpdateAlunoAmbientesCommand>
{
    public UpdateAlunoAmbientesCommandValidator()
    {
    }
}

public class UpdateAlunoAmbientesCommandHandler : IRequestHandler<UpdateAlunoAmbientesCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateAlunoAmbientesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateAlunoAmbientesCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
