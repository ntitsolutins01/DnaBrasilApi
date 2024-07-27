namespace DnaBrasilApi.Application.Escolaridades.Commands.UpdateEscolaridade;

public class UpdateEscolaridadeCommandValidator : AbstractValidator<UpdateEscolaridadeCommand>
{
    public UpdateEscolaridadeCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(100)
            .NotEmpty();
        RuleFor(v => v.Status)
            .NotNull();
    }
}
