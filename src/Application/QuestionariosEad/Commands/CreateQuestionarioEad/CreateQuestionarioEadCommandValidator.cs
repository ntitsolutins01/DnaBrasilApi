using DnaBrasilApi.Application.QuestionarioEadsEad.Commands.CreateQuestionarioEad;

namespace DnaBrasilApi.Application.QuestionariosEadsEad.Commands.CreateQuestionariosEad;

public class CreateQuestionarioEadCommandValidator : AbstractValidator<CreateQuestionarioEadCommand>
{
    public CreateQuestionarioEadCommandValidator()
    {
        
        RuleFor(v => v.Pergunta)
            .MaximumLength(400)
            .NotEmpty();
    }
}
