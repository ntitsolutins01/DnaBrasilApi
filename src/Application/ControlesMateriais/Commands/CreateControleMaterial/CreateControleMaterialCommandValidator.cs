namespace DnaBrasilApi.Application.ControlesMateriais.Commands.CreateControleMaterial;
internal class CreateControleMaterialCommandValidator : AbstractValidator<CreateControleMaterialCommand>
{
    public CreateControleMaterialCommandValidator()
    {
        RuleFor(v => v.Descricao)
            .MaximumLength(500)
            .NotEmpty();
        RuleFor(v => v.UnidadeMedida)
            .MaximumLength(15)
            .NotEmpty();
    }
}
