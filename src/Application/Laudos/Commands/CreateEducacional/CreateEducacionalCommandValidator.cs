namespace DnaBrasilApi.Application.Laudos.Commands.CreateVocacional;

public class CreateVocacionalCommandValidator : AbstractValidator<CreateVocacionalCommand>
{
    public CreateVocacionalCommandValidator()
    {
        RuleFor(v => v.Respostas)
            .MaximumLength(500)
            .NotEmpty();
    }
}
