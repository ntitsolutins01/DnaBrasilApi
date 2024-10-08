namespace DnaBrasilApi.Application.Laudos.Commands.CreateConsumoAlimentar;

public class CreateConsumoAlimentarCommandValidator : AbstractValidator<CreateConsumoAlimentarCommand>
{
    public CreateConsumoAlimentarCommandValidator()
    {
        RuleFor(v => v.Respostas)
            .MaximumLength(500)
            .NotEmpty();
    }
}
