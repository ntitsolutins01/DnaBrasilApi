namespace DnaBrasilApi.Application.AlunosCursos.Commands.UpdateAlunoCurso;
internal class UpdateAlunoCursoCommandValidator : AbstractValidator<UpdateAlunoCursoCommand>
{
    public UpdateAlunoCursoCommandValidator()
    {
        RuleFor(v => v.Progesso)
            .GreaterThan(0)
            .WithMessage("O progresso deve ser maior que zero.")
            .LessThanOrEqualTo(100)
            .WithMessage("O progresso deve ser menor ou igual a cem.");
    }
}
