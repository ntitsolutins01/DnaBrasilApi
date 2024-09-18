namespace DnaBrasilApi.Application.RespostasEad.Commands.UpdateRespostaEad;

public class UpdateRespostaEadCommandValidator : AbstractValidator<UpdateRespostaEadCommand>
{
    public UpdateRespostaEadCommandValidator()
    {
        RuleFor(v => v.RespostaQuestionarioEad)
            .MaximumLength(300);
    }
}
