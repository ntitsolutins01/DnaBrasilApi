namespace DnaBrasilApi.Application.ControlesFrequenciasEscolares.Commands.UpdateControleFrequenciaEscolar;
internal class UpdateControleFrequenciaEscolarCommandValidator : AbstractValidator<UpdateControleFrequenciaEscolarCommand>
{
    public UpdateControleFrequenciaEscolarCommandValidator()
    {
        RuleFor(v => v.Controle)
            .MaximumLength(1)
            .NotEmpty();
    }
}
