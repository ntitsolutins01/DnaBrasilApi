namespace DnaBrasilApi.Application.Laudos.Commands.CreateEducacional;

public class CreateEducacionalCommandValidator : AbstractValidator<CreateEducacionalCommand>
{
    public CreateEducacionalCommandValidator()
    {
        RuleFor(v => v.Respostas)
            .MaximumLength(500)
            .NotEmpty();
    }
}
