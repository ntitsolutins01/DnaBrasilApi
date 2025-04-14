namespace DnaBrasilApi.Application.ControlesFrequencias.Commands.UpdateControleFrequencia;

public class UpdateControleFrequenciaCommandValidator : AbstractValidator<UpdateControleFrequenciaCommand>
{
    public UpdateControleFrequenciaCommandValidator()
    {
        RuleFor(v => v.Presenca)
            .MaximumLength(1);
        RuleFor(v => v.Justificativa)
            .MaximumLength(500);
    }
}
