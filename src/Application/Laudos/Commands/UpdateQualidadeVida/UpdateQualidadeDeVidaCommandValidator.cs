namespace DnaBrasilApi.Application.Laudos.Commands.UpdateQualidadeVida;

public class UpdateQualidadeDeVidaCommandValidator : AbstractValidator<UpdateQualidadeDeVidaCommand>
{
    public UpdateQualidadeDeVidaCommandValidator()
    {
        RuleFor(v => v.Resposta)
            .MaximumLength(100)
            .NotEmpty();
    }
}
