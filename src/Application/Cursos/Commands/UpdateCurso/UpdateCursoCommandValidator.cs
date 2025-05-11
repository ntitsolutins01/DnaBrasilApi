namespace DnaBrasilApi.Application.Cursos.Commands.UpdateCurso;
internal class UpdateCursoCommandValidator : AbstractValidator<UpdateCursoCommand>
{
    public UpdateCursoCommandValidator()
    {
        RuleFor(v => v.Titulo)
            .MaximumLength(150)
            .NotEmpty();
        RuleFor(v => v.Descricao)
            .MaximumLength(500)
            .NotEmpty();
        RuleFor(v => v.Imagem)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.NomeImagem)
            .MaximumLength(100)
            .NotEmpty();
    }
}
