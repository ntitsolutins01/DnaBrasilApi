namespace DnaBrasilApi.Application.Laudos.Commands.CreateSaudeBucal;

public class CreateSaudeBucalCommandValidator : AbstractValidator<CreateSaudeBucalCommand>
{
    public CreateSaudeBucalCommandValidator()
    {
        RuleFor(v => v.Respostas)
            .MaximumLength(500);
    }
}
