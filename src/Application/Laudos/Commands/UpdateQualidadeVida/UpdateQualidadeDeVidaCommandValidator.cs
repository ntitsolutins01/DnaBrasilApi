namespace DnaBrasilApi.Application.Laudos.Commands.UpdateQualidadeDeVida;

public class UpdateQualidadeDeVidaCommandValidator : AbstractValidator<UpdateQualidadeDeVidaCommand>
{
    public UpdateQualidadeDeVidaCommandValidator()
    {
        RuleFor(v => v.Resposta)
            .MaximumLength(100)
            .NotEmpty();
    }
}
