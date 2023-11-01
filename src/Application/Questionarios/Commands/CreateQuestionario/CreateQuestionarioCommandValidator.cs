namespace DnaBrasil.Application.Questionarios.Commands.CreateQuestionário;

public class CreateQuestionarioCommandValidator : AbstractValidator<CreateQuestionarioCommand>
{
    public CreateQuestionarioCommandValidator()
    {
        RuleFor(v => v.Tipo)
            .NotEmpty();
        RuleFor(v => v.Pergunta)
            .MaximumLength(200)
            .NotEmpty();
    }
}
