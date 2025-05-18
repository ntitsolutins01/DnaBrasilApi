namespace DnaBrasilApi.Application.TipoLaudos.Commands.CreateTipoLaudos;
internal class CreateTipoLaudosCommandValidator : AbstractValidator<CreateTipoLaudosCommand>
{
    public CreateTipoLaudosCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.Descricao)
            .MaximumLength(200)
            .NotEmpty();
    }
}
