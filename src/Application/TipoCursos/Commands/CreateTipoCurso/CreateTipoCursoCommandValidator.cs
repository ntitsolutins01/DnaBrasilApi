namespace DnaBrasilApi.Application.TipoCursos.Commands.CreateTipoCurso;
internal class CreateTipoCursoCommandValidator : AbstractValidator<CreateTipoCursoCommand>
{
    public CreateTipoCursoCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty();
    }
}
