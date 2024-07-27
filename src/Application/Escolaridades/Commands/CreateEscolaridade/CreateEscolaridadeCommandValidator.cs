namespace DnaBrasilApi.Application.Escolaridades.Commands.CreateEscolaridade;

public class CreateEscolaridadeCommandValidator : AbstractValidator<CreateEscolaridadeCommand>
{
    public CreateEscolaridadeCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(100)
            .NotNull().NotEmpty();
    }
}
