namespace DnaBrasil.Application.Localidades.Commands.UpdateLocalidade;

public class UpdateLocalidadeCommandValidator : AbstractValidator<UpdateLocalidadeCommand>
{
    public UpdateLocalidadeCommandValidator()
    {

        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty().NotNull();
        RuleFor(v => v.Descricao)
            .MaximumLength(300);
        //RuleFor(v => v.Municipio)
        //    .NotNull();
        //RuleFor(v => v.Contratos)
        //    .NotNull();
    }
}
