namespace DnaBrasilApi.Application.GrauParentescos.Commands.CreateGrauParentesco;
internal class CreateGrauParentescosCommandValidator : AbstractValidator<CreateGrauParentescoCommand>
{
    public CreateGrauParentescosCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(20)
            .NotEmpty();

    }
}
