namespace DnaBrasilApi.Application.Questionarios.Commands.CreateQuestionario;

public class CreateQuestionarioCommandValidator : AbstractValidator<CreateQuestionarioCommand>
{
    public CreateQuestionarioCommandValidator()
    {
        
        RuleFor(v => v.Pergunta)
            .MaximumLength(400)
            .NotEmpty();
    }
}
