using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Commands.UpdateDependencia;

public class UpdateDependenciaCommandValidator : AbstractValidator<UpdateDependenciaCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateDependenciaCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        
    }
}
