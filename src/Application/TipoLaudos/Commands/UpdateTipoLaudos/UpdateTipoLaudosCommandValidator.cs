namespace DnaBrasilApi.Application.TipoLaudos.Commands.UpdateTipoLaudo;
internal class UpdateTipoLaudosCommandValidator : AbstractValidator<UpdateTipoLaudoCommand>
{
    public UpdateTipoLaudosCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.Descricao)
            .MaximumLength(200)
            .NotEmpty();
    }
}
