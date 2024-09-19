namespace DnaBrasilApi.Application.RespostasEad.Commands.UpdateRespostaEad;

public class UpdateRespostaEadCommandValidator : AbstractValidator<UpdateRespostaEadCommand>
{
    public UpdateRespostaEadCommandValidator()
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
