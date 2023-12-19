namespace DnaBrasilApi.Application.Respostas.Commands.CreateResposta;

public class CreateRespostaCommandValidator : AbstractValidator<CreateRespostaCommand>
{
    public CreateRespostaCommandValidator()
    {
        RuleFor(v => v.RespostaQuestionario)
            .MaximumLength(300)
            .NotEmpty();
    }
}
