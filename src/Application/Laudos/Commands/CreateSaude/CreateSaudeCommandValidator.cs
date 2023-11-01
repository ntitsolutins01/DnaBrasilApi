namespace DnaBrasil.Application.Laudos.Commands.CreateSaude;

public class CreateSaudeCommandValidator : AbstractValidator<CreateSaudeCommand>
{
    public CreateSaudeCommandValidator()
    {
        RuleFor(v => v.Profissional)
            .NotEmpty();
        RuleFor(v => v.Altura)
            .NotEmpty();
        RuleFor(v => v.Massa)
            .NotEmpty();
        RuleFor(v => v.Envergadura)
            .NotEmpty();
    }
}
