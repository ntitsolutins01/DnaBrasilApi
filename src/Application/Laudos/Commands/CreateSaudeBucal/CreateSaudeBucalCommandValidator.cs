namespace DnaBrasil.Application.Laudos.Commands.CreateSaudeBucal;

public class CreateSaudeBucalCommandValidator : AbstractValidator<CreateSaudeBucalCommand>
{
    public CreateSaudeBucalCommandValidator()
    {
        RuleFor(v => v.Profissional)
            .NotEmpty();
        RuleFor(v => v.Questionario)
            .NotEmpty();
        RuleFor(v => v.Resposta)
            .MaximumLength(100)
            .NotEmpty();
    }
}
