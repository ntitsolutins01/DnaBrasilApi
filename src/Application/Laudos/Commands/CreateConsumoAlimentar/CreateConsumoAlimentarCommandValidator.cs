namespace DnaBrasil.Application.Laudos.Commands.CreateConsumoAlimentar;

public class CreateConsumoAlimentarCommandValidator : AbstractValidator<CreateConsumoAlimentarCommand>
{
    public CreateConsumoAlimentarCommandValidator()
    {
        RuleFor(v => v.Profissional)
            .NotNull();
        RuleFor(v => v.Questionario)
            .NotNull();
        RuleFor(v => v.Resposta)
            .MaximumLength(50)
            .NotEmpty();
    }
}
