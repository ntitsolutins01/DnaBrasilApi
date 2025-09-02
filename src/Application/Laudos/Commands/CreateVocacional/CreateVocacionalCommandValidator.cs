using DnaBrasilApi.Application.Laudos.Commands.CreateEducacional;

namespace DnaBrasilApi.Application.Laudos.Commands.CreateVocacional;

public class CreateEducacionalCommandValidator : AbstractValidator<CreateEducacionalCommand>
{
    public CreateEducacionalCommandValidator()
    {
        RuleFor(v => v.Respostas)
            .MaximumLength(500)
            .NotEmpty();
    }
}
