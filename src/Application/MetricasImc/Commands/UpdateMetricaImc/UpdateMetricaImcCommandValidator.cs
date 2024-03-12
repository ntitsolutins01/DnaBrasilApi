namespace DnaBrasilApi.Application.MetricasImc.Commands.UpdateMetricaImc;

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
