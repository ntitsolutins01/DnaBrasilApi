namespace DnaBrasilApi.Application.Alunos.Commands.CreateAlunoPresencas;
internal class CreateAlunoPresencaCommandValidator : AbstractValidator<CreateAlunoPresencaCommand>
{
    public CreateAlunoPresencaCommandValidator()
    {
        RuleFor(v => v.Presenca)
            .NotEmpty();
        RuleFor(v => v.Justificativa)
            .MaximumLength(100);
    }
}
