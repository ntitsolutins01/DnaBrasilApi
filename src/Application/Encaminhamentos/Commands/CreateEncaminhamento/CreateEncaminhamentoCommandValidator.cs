using DnaBrasilApi.Application.Encaminhamentos.Commands.CreateEncaminhamento;

namespace DnaBrasilApi.Application.Encaminhamentos.Commands.CreateEncaminhamento;
internal class CreateEncaminhamentoCommandValidator : AbstractValidator<CreateEncaminhamentoCommand>
{
    public CreateEncaminhamentoCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty();
        RuleFor(v => v.Parametro)
            .MaximumLength(150)
            .NotEmpty();
        RuleFor(v => v.Descricao)
            .MaximumLength(500)
            .NotEmpty();
    }
}
