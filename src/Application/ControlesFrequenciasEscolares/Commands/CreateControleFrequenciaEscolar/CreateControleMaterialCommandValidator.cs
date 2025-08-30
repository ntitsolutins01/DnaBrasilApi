namespace DnaBrasilApi.Application.ControlesFrequenciasEscolares.Commands.CreateControleFrequenciaEscolar;
internal class CreateControleFrequenciaEscolarCommandValidator : AbstractValidator<CreateControleFrequenciaEscolarCommand>
{
    public CreateControleFrequenciaEscolarCommandValidator()
    {
        RuleFor(v => v.Controle)
            .MaximumLength(1)
            .NotEmpty();
    }
}
