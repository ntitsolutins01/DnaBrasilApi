

namespace DnaBrasilApi.Application.TextosImagensQuestoes.Commands.CreateTextoImagemQuestao;

public class CreateTextoQuestaoCommandValidator : AbstractValidator<CreateTextoImagemQuestaoCommand>
{
    public CreateTextoQuestaoCommandValidator()
    {
        RuleFor(v => v.TextoImagem)
            .MaximumLength(1000);
        RuleFor(v => v.Tipo)
            .MaximumLength(1);
    }
}
