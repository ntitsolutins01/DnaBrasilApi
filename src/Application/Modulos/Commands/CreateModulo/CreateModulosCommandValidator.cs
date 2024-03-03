namespace DnaBrasilApi.Application.Modulos.Commands.CreateModulo;
internal class CreateModulosCommandValidator : AbstractValidator<CreateModuloCommand>
{
    public CreateModulosCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty();
        
    }
}
