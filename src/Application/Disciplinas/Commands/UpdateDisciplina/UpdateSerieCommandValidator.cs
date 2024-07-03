namespace DnaBrasilApi.Application.Disciplinas.Commands.UpdateDisciplina;
internal class UpdateDisciplinaCommandValidator : AbstractValidator<UpdateDisciplinaCommand>
{
    public UpdateDisciplinaCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty();
        RuleFor(v => v.Descricao)
            .MaximumLength(500)
            .NotEmpty();

    }
}
