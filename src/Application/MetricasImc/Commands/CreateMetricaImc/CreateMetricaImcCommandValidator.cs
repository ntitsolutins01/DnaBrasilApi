namespace DnaBrasilApi.Application.MetricasImc.Commands.CreateMetricaImc;

public class CreateMetricaImcCommandValidator : AbstractValidator<CreateMetricaImcCommand>
{
    public CreateMetricaImcCommandValidator()
    {
        RuleFor(v => v.Classificacao)
            .MaximumLength(100);
        RuleFor(v => v.Sexo)
            .MaximumLength(1);
    }
}
