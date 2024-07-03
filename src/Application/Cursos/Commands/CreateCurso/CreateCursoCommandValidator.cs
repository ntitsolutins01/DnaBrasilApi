namespace DnaBrasilApi.Application.Cursos.Commands.CreateCurso;
internal class CreateCursoCommandValidator : AbstractValidator<CreateCursoCommand>
{
    public CreateCursoCommandValidator()
    {
        RuleFor(v => v.Titulo)
            .MaximumLength(150)
            .NotEmpty();
        RuleFor(v => v.Descricao)
            .MaximumLength(500)
            .NotEmpty();
    }
}
