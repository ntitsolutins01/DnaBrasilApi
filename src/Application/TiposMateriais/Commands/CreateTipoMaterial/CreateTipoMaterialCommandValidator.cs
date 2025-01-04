
namespace DnaBrasilApi.Application.TiposMateriais.Commands.CreateTipoMaterial;
internal class CreateTipoMaterialCommandValidator : AbstractValidator<CreateTipoMaterialCommand>
{
    public CreateTipoMaterialCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(250)
            .NotEmpty()
            .WithMessage("O nome é obrigatório.");
    }
}
