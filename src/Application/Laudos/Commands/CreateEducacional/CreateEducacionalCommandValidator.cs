using DnaBrasilApi.Application.Laudos.Commands.CreateVocacional;

namespace DnaBrasilApi.Application.Laudos.Commands.CreateEducacional;

public class CreateVocacionalCommandValidator : AbstractValidator<CreateVocacionalCommand>
{
    public CreateVocacionalCommandValidator()
    {
        RuleFor(v => v.Respostas)
            .MaximumLength(500)
            .NotEmpty();
    }
}
