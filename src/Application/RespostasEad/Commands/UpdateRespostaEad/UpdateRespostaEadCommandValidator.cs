namespace DnaBrasilApi.Application.RespostasEad.Commands.UpdateRespostaEad;

public class UpdateRespostaEadCommandValidator : AbstractValidator<UpdateRespostaEadCommand>
{
    public UpdateRespostaEadCommandValidator()
    {
        RuleFor(v => v.Resposta)
            .MaximumLength(2000)
            .NotEmpty();
        RuleFor(v => v.TipoResposta)
            .MaximumLength(1)
            .NotEmpty();
    }
}
