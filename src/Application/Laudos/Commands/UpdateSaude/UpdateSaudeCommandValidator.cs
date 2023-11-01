using DnaBrasil.Application.Laudos.Commands.UpdateSaude;

namespace DnaBrasil.Application.ConsumosAlimentares.Commands.UpdateSaude;

public class UpdateSaudeCommandValidator : AbstractValidator<UpdateSaudeCommand>
{
    public UpdateSaudeCommandValidator()
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
