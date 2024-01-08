namespace DnaBrasilApi.Application.Modulos.Commands.UpdateModulo;
internal class UpdateModuloCommandValidator : AbstractValidator<UpdateModuloCommand>
{
    public UpdateModuloCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty();
    }
}
