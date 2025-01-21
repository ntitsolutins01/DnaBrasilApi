
using DnaBrasilApi.Application.Categorias.Commands.CreateCategoria;

namespace DnaBrasilApi.Application.Categorias.Commands.CreateCategoria;
internal class CreateCategoriaCommandValidator : AbstractValidator<CreateCategoriaCommand>
{
    public CreateCategoriaCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(50)
            .NotEmpty()
            .WithMessage("O Nome é obrigatório.");
        RuleFor(v => v.Descricao)
            .MaximumLength(500);
    }
}
