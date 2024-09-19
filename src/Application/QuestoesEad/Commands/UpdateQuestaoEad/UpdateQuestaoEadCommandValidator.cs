namespace DnaBrasilApi.Application.QuestoesEad.Commands.UpdateQuestaoEad;

public class UpdateQuestaoEadCommandValidator : AbstractValidator<UpdateQuestaoEadCommand>
{
    public UpdateQuestaoEadCommandValidator()
    {
       
        RuleFor(v => v.Pergunta)
            .MaximumLength(400)
            .NotEmpty();
    }
}
