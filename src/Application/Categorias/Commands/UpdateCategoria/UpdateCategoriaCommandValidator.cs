namespace DnaBrasilApi.Application.Categorias.Commands.UpdateCategoria;
internal class UpdateCategoriaCommandValidator : AbstractValidator<UpdateCategoriaCommand>
{
    public UpdateCategoriaCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(50)
            .NotEmpty()
            .WithMessage("O Nome é obrigatório.");
        RuleFor(v => v.Descricao)
            .MaximumLength(500);
    }
}
