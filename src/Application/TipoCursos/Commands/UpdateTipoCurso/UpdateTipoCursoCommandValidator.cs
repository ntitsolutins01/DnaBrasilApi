namespace DnaBrasilApi.Application.TipoCursos.Commands.UpdateTipoCurso;
internal class UpdateTipoCursoCommandValidator : AbstractValidator<UpdateTipoCursoCommand>
{
    public UpdateTipoCursoCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty();
    }
}
