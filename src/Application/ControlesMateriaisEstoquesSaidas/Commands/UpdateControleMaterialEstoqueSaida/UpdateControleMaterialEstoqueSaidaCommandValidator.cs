namespace DnaBrasilApi.Application.ControlesMateriaisEstoquesSaidas.Commands.UpdateControleMaterialEstoqueSaida;
internal class UpdateControleMaterialEstoqueSaidaCommandValidator : AbstractValidator<UpdateControleMaterialEstoqueSaidaCommand>
{
    public UpdateControleMaterialEstoqueSaidaCommandValidator()
    {
        RuleFor(v => v.Solicitante)
            .MaximumLength(250);
    }
}
