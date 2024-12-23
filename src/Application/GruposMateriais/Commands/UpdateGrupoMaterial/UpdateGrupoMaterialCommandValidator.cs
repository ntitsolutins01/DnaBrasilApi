namespace DnaBrasilApi.Application.GruposMateriais.Commands.UpdateGrupoMaterial;
internal class UpdateGrupoMaterialCommandValidator : AbstractValidator<UpdateGrupoMaterialCommand>
{
    public UpdateGrupoMaterialCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(250)
            .NotEmpty()
            .WithMessage("O nome é obrigatório.");
    }
}
