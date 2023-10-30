namespace DnaBrasil.Application.Deficiencias.Commands.UpdateDeficiencia;

public class UpdateDeficienciaCommandValidator : AbstractValidator<UpdateDeficienciaCommand>
{
    public UpdateDeficienciaCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(80)
            .NotEmpty();

        RuleFor(v => v.Status)
            .NotNull().NotEmpty();
    }
}
