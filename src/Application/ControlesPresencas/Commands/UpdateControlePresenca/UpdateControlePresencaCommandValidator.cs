namespace DnaBrasilApi.Application.ControlesPresencas.Commands.UpdateControlePresenca;

public class UpdateControlePresencaCommandValidator : AbstractValidator<UpdateControlePresencaCommand>
{
    public UpdateControlePresencaCommandValidator()
    {
        RuleFor(v => v.Controle)
            .MaximumLength(1)
            .NotNull().NotEmpty();
        RuleFor(v => v.Justificativa)
            .MaximumLength(500)
            .NotNull().NotEmpty();
    }
}
