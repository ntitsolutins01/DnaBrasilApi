namespace DnaBrasilApi.Application.QuestoesEad.Commands.CreateQuestaoEad;

public class CreateQuestaoEadCommandValidator : AbstractValidator<CreateQuestaoEadCommand>
{
    public CreateQuestaoEadCommandValidator()
    {
        
        RuleFor(v => v.Pergunta)
            .MaximumLength(400)
            .NotEmpty();
    }
}
