
namespace DnaBrasilApi.Application.ControlesAcessosAulas.Commands.UpdateControleAcessoAula;
internal class UpdateControleAcessoAulaCommandValidator : AbstractValidator<UpdateControleAcessoAulaCommand>
{
    public UpdateControleAcessoAulaCommandValidator()
    {
        RuleFor(v => v.LiberacaoAula)
            .MaximumLength(100);
    }
}
