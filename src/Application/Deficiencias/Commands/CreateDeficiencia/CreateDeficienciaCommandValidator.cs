namespace DnaBrasil.Application.Deficiencias.Commands.CreateDeficiencia;

public class CreateDeficienciaCommandValidator : AbstractValidator<CreateDeficienciaCommand>
{
    public CreateDeficienciaCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(80)
            .NotEmpty();

        RuleFor(v => v.Status)
            .NotNull().NotEmpty();
    }
}
