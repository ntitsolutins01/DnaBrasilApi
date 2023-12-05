namespace DnaBrasilApi.Application.Ambientes.Commands.UpdateAmbiente;

public class UpdateAmbienteCommandValidator : AbstractValidator<UpdateAmbienteCommand>
{
    public UpdateAmbienteCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(100)
            .NotEmpty();
    }
}
