namespace DnaBrasilApi.Application.Questionarios.Commands.CreateQuestionario;

public class CreateQuestionarioCommandValidator : AbstractValidator<CreateQuestionarioCommand>
{
    public CreateQuestionarioCommandValidator()
    {
        RuleFor(v => v.TipoLaudoId)
            .NotEqual(0);
        RuleFor(v => v.Pergunta)
            .MaximumLength(400)
            .NotEmpty();
    }
}
