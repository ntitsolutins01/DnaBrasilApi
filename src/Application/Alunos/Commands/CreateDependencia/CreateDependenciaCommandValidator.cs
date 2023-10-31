using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Commands.CreateDependencia;
public class CreateDependenciaCommandValidator : AbstractValidator<CreateDependenciaCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateDependenciaCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        
    }
}
