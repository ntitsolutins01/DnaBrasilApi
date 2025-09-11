namespace DnaBrasilApi.Application.GrauParentescos.Commands.UpdateGrauParentesco;
internal class UpdateGrauParentescoCommandValidator : AbstractValidator<UpdateGrauParentescoCommand>
{
    public UpdateGrauParentescoCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(20)
            .NotEmpty();

    }
}
