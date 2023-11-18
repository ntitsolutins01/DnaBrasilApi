namespace DnaBrasilApi.Application.Laudos.Commands.CreateVocacional;

public class CreateVocacionalCommandValidator : AbstractValidator<CreateVocacionalCommand>
{
    public CreateVocacionalCommandValidator()
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
