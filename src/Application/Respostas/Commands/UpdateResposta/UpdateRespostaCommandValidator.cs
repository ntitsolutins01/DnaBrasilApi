namespace DnaBrasilApi.Application.Respostas.Commands.UpdateResposta;

public class UpdateRespostaCommandValidator : AbstractValidator<UpdateRespostaCommand>
{
    public UpdateRespostaCommandValidator()
    {
        RuleFor(v => v.RespostaQuestionario)
            .MaximumLength(300);
        RuleFor(v => v.Descricao)
            .MaximumLength(500);
    }
}
