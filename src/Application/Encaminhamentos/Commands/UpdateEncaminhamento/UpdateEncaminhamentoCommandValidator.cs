namespace DnaBrasilApi.Application.Encaminhamentos.Commands.UpdateEncaminhamento;
internal class UpdateEncaminhamentoCommandValidator : AbstractValidator<UpdateEncaminhamentoCommand>
{
    public UpdateEncaminhamentoCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty();
        RuleFor(v => v.Parametro)
            .MaximumLength(150)
            .NotEmpty();
        RuleFor(v => v.Descricao)
            .MaximumLength(500);
    }
}
