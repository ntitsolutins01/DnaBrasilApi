using DnaBrasilApi.Application.ControlesMateriaisEstoquesSaidas.Commands.CreateControleMaterialEstoqueSaida;

internal class CreateControleMaterialEstoqueSaidaCommandValidator : AbstractValidator<CreateControleMaterialEstoqueSaidaCommand>
{
    public CreateControleMaterialEstoqueSaidaCommandValidator()
    {
        RuleFor(v => v.Solicitante)
            .MaximumLength(250);
    }
}
