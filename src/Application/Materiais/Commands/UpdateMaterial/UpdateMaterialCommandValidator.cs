namespace DnaBrasilApi.Application.Materiais.Commands.UpdateMaterial;
internal class UpdateMaterialCommandValidator : AbstractValidator<UpdateMaterialCommand>
{
    public UpdateMaterialCommandValidator()
    {
        RuleFor(v => v.UnidadeMedida)
            .MaximumLength(100)
            .NotEmpty()
            .WithMessage("A descrição é obrigatória.");
        RuleFor(v => v.Descricao)
            .MaximumLength(250)
            .WithMessage("A descrição máxima é 250 caracteres.");
    }
}
