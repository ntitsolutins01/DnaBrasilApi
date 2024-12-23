using DnaBrasilApi.Application.GruposMateriais.Commands.CreateGrupoMaterial;

namespace DnaBrasilApi.Application.GruposMateriais.Commands.CreateGrupoMaterial;
internal class CreateGrupoMaterialCommandValidator : AbstractValidator<CreateGrupoMaterialCommand>
{
    public CreateGrupoMaterialCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(250)
            .NotEmpty()
            .WithMessage("O nome é obrigatório.");
    }
}
