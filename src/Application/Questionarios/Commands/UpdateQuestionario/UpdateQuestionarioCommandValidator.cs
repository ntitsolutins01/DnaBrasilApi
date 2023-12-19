namespace DnaBrasilApi.Application.Questionarios.Commands.UpdateQuestionario;

public class UpdateQuestionarioCommandValidator : AbstractValidator<UpdateQuestionarioCommand>
{
    public UpdateQuestionarioCommandValidator()
    {
       
        RuleFor(v => v.Pergunta)
            .MaximumLength(400)
            .NotEmpty();
    }
}
