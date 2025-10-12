namespace DnaBrasilApi.Application.EtapasEnsino.Commands.UpdateEtapaEnsino;

public class UpdateEtapaEnsinoCommandValidator : AbstractValidator<UpdateEtapaEnsinoCommand>
{
    public UpdateEtapaEnsinoCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(80)
            .NotEmpty();

        RuleFor(v => v.Status)
            .NotNull();
    }
}
