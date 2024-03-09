using DnaBrasilApi.Application.TextosLaudos.Commands.CreateTextoLaudo;

namespace DnaBrasilApi.Application.TextosLaudos.Commands.CreateTextoLaudo;

public class CreateTextoLaudoCommandValidator : AbstractValidator<CreateTextoLaudoCommand>
{
    public CreateTextoLaudoCommandValidator()
    {
        RuleFor(v => v.Aviso)
            .MaximumLength(100);
        RuleFor(v => v.Texto)
            .MaximumLength(500);
        RuleFor(v => v.Classificacao)
            .MaximumLength(100);
        RuleFor(v => v.Sexo)
            .MaximumLength(1);
    }
}
