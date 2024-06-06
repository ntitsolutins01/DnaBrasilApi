namespace DnaBrasilApi.Application.LinhasAcoes.Commands.CreateLinhaAcao;

public class CreateLinhaAcaoCommandValidator : AbstractValidator<CreateLinhaAcaoCommand>
{
    public CreateLinhaAcaoCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(300)
            .NotEmpty();
    }
}
