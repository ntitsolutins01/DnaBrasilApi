namespace DnaBrasilApi.Application.TiposParcerias.Commands.UpdateTipoParceria;

public class UpdateTipoParceriaCommandValidator : AbstractValidator<UpdateTipoParceriaCommand>
{
    public UpdateTipoParceriaCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty();
        RuleFor(v => v.Parceria)
            .NotNull();
    }
}
