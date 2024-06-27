namespace DnaBrasilApi.Application.ControlesAcessosAulas.Commands.CreateControleAcessoAula;
internal class CreateControleAcessoAulaCommandValidator : AbstractValidator<CreateControleAcessoAulaCommand>
{
    public CreateControleAcessoAulaCommandValidator()
    {
        RuleFor(v => v.LiberacaoAula)
            .MaximumLength(100);
        
    }
}
