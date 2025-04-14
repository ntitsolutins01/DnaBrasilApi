using DnaBrasilApi.Application.ControlesFrequencias.Commands.CreateControleFrequencia;

namespace DnaBrasilApi.Application.ControlesFrequencias.Commands.CreateControleFrequencia;

public class CreateControleFrequenciaCommandValidator : AbstractValidator<CreateControleFrequenciaCommand>
{
    public CreateControleFrequenciaCommandValidator()
    {
        RuleFor(v => v.Presenca)
            .MaximumLength(1);
        RuleFor(v => v.Justificativa)
            .MaximumLength(500);
    }
}
