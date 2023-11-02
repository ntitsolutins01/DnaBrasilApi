namespace DnaBrasil.Application.Questionarios.Commands.CreateQuestionário;

public class CreateQuestionarioCommandValidator : AbstractValidator<CreateQuestionarioCommand>
{
    public CreateQuestionarioCommandValidator()
    {
        RuleFor(v => v.Tipo)
            .NotNull();
        RuleFor(v => v.Pergunta)
            .MaximumLength(400)
            .NotEmpty();
    }
}
