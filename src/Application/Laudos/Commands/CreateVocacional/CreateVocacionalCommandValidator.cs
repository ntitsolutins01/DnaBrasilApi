namespace DnaBrasilApi.Application.Laudos.Commands.CreateVocacional;

public class CreateVocacionalCommandValidator : AbstractValidator<CreateVocacionalCommand>
{
    public CreateVocacionalCommandValidator()
    {
        RuleFor(v => v.Resposta)
            .MaximumLength(500)
            .NotEmpty();
    }
}
