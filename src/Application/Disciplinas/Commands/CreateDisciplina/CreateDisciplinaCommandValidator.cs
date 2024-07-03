namespace DnaBrasilApi.Application.Disciplinas.Commands.CreateDisciplina;
internal class CreateDisciplinasCommandValidator : AbstractValidator<CreateDisciplinaCommand>
{
    public CreateDisciplinasCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty();
        RuleFor(v => v.Descricao)
            .MaximumLength(500)
            .NotEmpty();

    }
}
