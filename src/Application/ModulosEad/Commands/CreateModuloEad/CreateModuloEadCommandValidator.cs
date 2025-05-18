namespace DnaBrasilApi.Application.ModulosEad.Commands.CreateModuloEad;
internal class CreateModuloEadCommandValidator : AbstractValidator<CreateModuloEadCommand>
{
    public CreateModuloEadCommandValidator()
    {
        RuleFor(v => v.Titulo)
            .MaximumLength(250)
            .NotEmpty()
            .WithMessage("O título é obrigatório.");
        RuleFor(v => v.Descricao)
            .MaximumLength(500)
            .WithMessage("A quantidade máxima de caracteres permitidos são de 500.");
    }
}
