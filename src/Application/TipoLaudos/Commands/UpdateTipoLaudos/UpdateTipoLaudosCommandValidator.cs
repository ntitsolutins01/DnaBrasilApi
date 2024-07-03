namespace DnaBrasilApi.Application.TipoLaudos.Commands.UpdateTipoLaudos;
internal class UpdateTipoLaudosCommandValidator : AbstractValidator<UpdateTipoLaudoCommand>
{
    public UpdateTipoLaudosCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(100)
            .NotEmpty();
        RuleFor(v => v.Descricao)
            .MaximumLength(300)
            .NotEmpty();
    }
}
