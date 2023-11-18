namespace DnaBrasilApi.Application.Usuarios.Commands.UpdateUsuario;

public class UpdateUsuarioCommandValidator : AbstractValidator<UpdateUsuarioCommand>
{
    public UpdateUsuarioCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotNull().NotEmpty();
        RuleFor(v => v.Email)
            .MaximumLength(100)
            .NotNull().NotEmpty();

        RuleFor(v => v.Status)
            .NotNull().NotEmpty();
    }
}
