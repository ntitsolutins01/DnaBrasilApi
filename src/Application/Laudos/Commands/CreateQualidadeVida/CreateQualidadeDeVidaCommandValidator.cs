namespace DnaBrasilApi.Application.Laudos.Commands.CreateQualidadeVida;

public class CreateQualidadeDeVidaCommandValidator : AbstractValidator<CreateQualidadeDeVidaCommand>
{
    public CreateQualidadeDeVidaCommandValidator()
    {
        RuleFor(v => v.AlunoId)
            .NotNull();
    }
}
