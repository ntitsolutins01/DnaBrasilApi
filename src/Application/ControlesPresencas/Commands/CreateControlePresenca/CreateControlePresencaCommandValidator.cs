namespace DnaBrasilApi.Application.ControlesPresencas.Commands.CreateControlePresenca;

public class CreateControlePresencaCommandValidator : AbstractValidator<CreateControlePresencaCommand>
{
    public CreateControlePresencaCommandValidator()
    {
        RuleFor(v => v.Controle)
            .MaximumLength(1)
            .NotNull().NotEmpty();
        RuleFor(v => v.Justificativa)
            .MaximumLength(500);
    }
}
