namespace DnaBrasilApi.Application.TextosQuestoes.Commands.UpdateTextoQuestao;

public class UpdateTextoQuestaoCommandValidator : AbstractValidator<UpdateTextoQuestaoCommand>
{
    public UpdateTextoQuestaoCommandValidator()
    {
        RuleFor(v => v.Texto)
            .MaximumLength(1000);
    }
}
