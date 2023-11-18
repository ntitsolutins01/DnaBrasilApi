namespace DnaBrasilApi.Application.Laudos.Commands.UpdateSaude;

public class UpdateSaudeCommandValidator : AbstractValidator<UpdateSaudeCommand>
{
    public UpdateSaudeCommandValidator()
    {
        RuleFor(v => v.Altura)
            .NotEmpty();
        RuleFor(v => v.Massa)
            .NotEmpty();
        RuleFor(v => v.Envergadura)
            .NotEmpty();
    }
}
