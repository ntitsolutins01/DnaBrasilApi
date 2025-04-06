namespace DnaBrasilApi.Application.ModulosEad.Commands.UpdateModuloEad;
internal class UpdateModuloEadCommandValidator : AbstractValidator<UpdateModuloEadCommand>
{
    public UpdateModuloEadCommandValidator()
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
