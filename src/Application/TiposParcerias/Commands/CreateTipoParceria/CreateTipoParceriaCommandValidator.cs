namespace DnaBrasilApi.Application.TiposParcerias.Commands.CreateTipoParceria;

public class CreateTipoParceriaCommandValidator : AbstractValidator<CreateTipoParceriaCommand>
{
    public CreateTipoParceriaCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotNull().NotEmpty();
        RuleFor(v => v.Parceria)
            .NotNull();
    }
}
