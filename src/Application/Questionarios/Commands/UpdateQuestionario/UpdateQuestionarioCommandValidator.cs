namespace DnaBrasil.Application.Questionarios.Commands.UpdateQuestionario;

public class UpdateQuestionarioCommandValidator : AbstractValidator<UpdateQuestionarioCommand>
{
    public UpdateQuestionarioCommandValidator()
    {
        //RuleFor(v => v.Tipo)
        //    .NotEmpty();
        RuleFor(v => v.Pergunta)
            .MaximumLength(200)
            .NotEmpty();
    }
}
