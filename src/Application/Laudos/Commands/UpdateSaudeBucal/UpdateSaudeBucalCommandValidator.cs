namespace DnaBrasil.Application.Laudos.Commands.UpdateSaudeBucal;

public class UpdateSaudeBucalCommandValidator : AbstractValidator<UpdateSaudeBucalCommand>
{
    public UpdateSaudeBucalCommandValidator()
    {
        RuleFor(v => v.Resposta)
            .MaximumLength(100)
            .NotEmpty();
    }
}
