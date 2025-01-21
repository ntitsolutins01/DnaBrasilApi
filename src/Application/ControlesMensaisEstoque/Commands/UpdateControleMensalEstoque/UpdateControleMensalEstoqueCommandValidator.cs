namespace DnaBrasilApi.Application.ControlesMensaisEstoque.Commands.UpdateControleMensalEstoque;
internal class UpdateControleMensalEstoqueCommandValidator : AbstractValidator<UpdateControleMensalEstoqueCommand>
{
    public UpdateControleMensalEstoqueCommandValidator()
    {
        RuleFor(v => v.JustificativaDanificadosExtraviados)
            .MaximumLength(250);
    }
}
