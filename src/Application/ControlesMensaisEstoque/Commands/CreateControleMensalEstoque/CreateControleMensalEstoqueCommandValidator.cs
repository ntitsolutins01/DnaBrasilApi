namespace DnaBrasilApi.Application.ControlesMensaisEstoque.Commands.CreateControleMensalEstoque;
internal class CreateControleMensalEstoqueCommandValidator : AbstractValidator<CreateControleMensalEstoqueCommand>
{
    public CreateControleMensalEstoqueCommandValidator()
    {
        RuleFor(v => v.JustificativaDanificadosExtraviados)
            .MaximumLength(250);
    }
}
