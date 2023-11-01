namespace DnaBrasil.Application.Laudos.Commands.CreateQualidadeDeVida;

public class CreateQualidadeDeVidaCommandValidator : AbstractValidator<CreateQualidadeDeVidaCommand>
{
    public CreateQualidadeDeVidaCommandValidator()
    {
        RuleFor(v => v.Profissional)
            .NotEmpty();
        RuleFor(v => v.Questionario)
            .NotEmpty();
        RuleFor(v => v.Resposta)
            .MaximumLength(100)
            .NotEmpty();
    }
}
