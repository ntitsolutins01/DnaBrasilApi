namespace DnaBrasil.Application.Locals.Commands.UpdateLocal;

public class UpdateLocalCommandValidator : AbstractValidator<UpdateLocalCommand>
{
    public UpdateLocalCommandValidator()
    {

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
