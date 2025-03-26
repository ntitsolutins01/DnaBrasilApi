
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Application.Alunos.Commands.CreateAlunoPresencas;
internal class CreateAlunoPresencaCommandValidator : AbstractValidator<CreateAlunoPresencaCommand>
{
    public CreateAlunoPresencaCommandValidator()
    {
        RuleFor(v => v.Presenca)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(1)
            .NotEmpty();
        RuleFor(v => v.Justificativa)
            .MaximumLength(100);
    }
}
