using DnaBrasilApi.Application.MetricasImc.Commands.UpdateMetricaImc;

namespace DnaBrasilApi.Application.TextosLaudos.Commands.UpdateMetricaImc;

public class UpdateMetricaImcCommandValidator : AbstractValidator<UpdateMetricaImcCommand>
{
    public UpdateMetricaImcCommandValidator()
    {
        RuleFor(v => v.Classificacao)
            .MaximumLength(100);
        RuleFor(v => v.Sexo)
            .MaximumLength(1);
    }
}
