namespace DnaBrasil.Application.ConsumosAlimentares.Commands.CreateConsumoAlimentar;

public class CreateConsumoAlimentarCommandValidator : AbstractValidator<CreateConsumoAlimentarCommand>
{
    public CreateConsumoAlimentarCommandValidator()
    {
        RuleFor(v => v.Resposta)
            .MaximumLength(50)
            .NotEmpty();
    }
}
