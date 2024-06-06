namespace DnaBrasilApi.Application.LinhasAcoes.Commands.UpdateLinhaAcao;

public class UpdateLinhaAcaoCommandValidator : AbstractValidator<UpdateLinhaAcaoCommand>
{
    public UpdateLinhaAcaoCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(300);
    }
}
