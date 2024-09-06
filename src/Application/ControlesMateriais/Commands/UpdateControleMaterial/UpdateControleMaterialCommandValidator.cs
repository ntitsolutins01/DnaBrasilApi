namespace DnaBrasilApi.Application.ControlesMateriais.Commands.UpdateControleMaterial;
internal class UpdateControleMaterialCommandValidator : AbstractValidator<UpdateControleMaterialCommand>
{
    public UpdateControleMaterialCommandValidator()
    {
        RuleFor(v => v.Descricao)
            .MaximumLength(500)
            .NotEmpty();
        RuleFor(v => v.UnidadeMedida)
            .MaximumLength(15)
            .NotEmpty();
    }
}
