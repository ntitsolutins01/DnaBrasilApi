namespace DnaBrasilApi.Application.TiposMateriais.Commands.UpdateTipoMaterial;
internal class UpdateTipoMaterialCommandValidator : AbstractValidator<UpdateTipoMaterialCommand>
{
    public UpdateTipoMaterialCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(250)
            .NotEmpty()
            .WithMessage("O nome é obrigatório.");
    }
}
