

namespace DnaBrasilApi.Application.TextosQuestoes.Commands.CreateTextoQuestao;

public class CreateTextoQuestaoCommandValidator : AbstractValidator<CreateTextoQuestaoCommand>
{
    public CreateTextoQuestaoCommandValidator()
    {
        RuleFor(v => v.Texto)
            .MaximumLength(1000);
    }
}
