namespace DnaBrasilApi.Application.TextosImagensQuestoes.Commands.UpdateTextoImagemQuestao;

public class UpdateTextoImagemQuestaoCommandValidator : AbstractValidator<UpdateTextoImagemQuestaoCommand>
{
    public UpdateTextoImagemQuestaoCommandValidator()
    {
        RuleFor(v => v.TextoImagem)
            .MaximumLength(1000);
        RuleFor(v => v.Tipo)
            .MaximumLength(1);
    }
}
