using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Locais.Commands.CreateLocal;

public class CreateLocalCommandValidator : AbstractValidator<CreateLocalCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateLocalCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty().NotNull();
        RuleFor(v => v.Descricao)
            .MaximumLength(300);
        RuleFor(v => v.Status)
            .NotNull().NotEmpty();
        RuleFor(v => v.Municipio)
            .NotNull();
        RuleFor(v => v.Contratos)
            .NotNull();
    }
}
