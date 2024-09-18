namespace DnaBrasilApi.Application.RespostasEad.Commands.CreateRespostaEad;

public class CreateRespostaEadCommandValidator : AbstractValidator<CreateRespostaEadCommand>
{
    public CreateRespostaEadCommandValidator()
    {
        RuleFor(v => v.RespostaQuestionarioEad)
            .MaximumLength(300)
            .NotEmpty();
    }
}
