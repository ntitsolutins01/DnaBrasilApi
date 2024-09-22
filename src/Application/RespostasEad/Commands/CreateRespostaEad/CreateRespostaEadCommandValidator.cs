namespace DnaBrasilApi.Application.RespostasEad.Commands.CreateRespostaEad;

public class CreateRespostaEadCommandValidator : AbstractValidator<CreateRespostaEadCommand>
{
    public CreateRespostaEadCommandValidator()
    {
        RuleFor(v => v.Resposta)
            .MaximumLength(1000)
            .NotEmpty();
        RuleFor(v => v.TipoResposta)
            .MaximumLength(1)
            .NotEmpty();
        RuleFor(v => v.TipoAlternativa)
            .MaximumLength(6);
    }
}
