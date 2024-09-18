namespace DnaBrasilApi.Application.QuestionariosEad.Commands.UpdateQuestionarioEad;

public class UpdateQuestionarioEadCommandValidator : AbstractValidator<UpdateQuestionarioEadCommand>
{
    public UpdateQuestionarioEadCommandValidator()
    {
       
        RuleFor(v => v.Pergunta)
            .MaximumLength(400)
            .NotEmpty();
    }
}
