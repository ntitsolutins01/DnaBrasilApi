namespace DnaBrasil.Application.Laudos.Commands.UpdateConsumoAlimentar;

public class UpdateConsumoAlimentarCommandValidator : AbstractValidator<UpdateConsumoAlimentarCommand>
{
    public UpdateConsumoAlimentarCommandValidator()
    {
        RuleFor(v => v.Resposta)
            .MaximumLength(100)
            .NotEmpty();
    }
}
