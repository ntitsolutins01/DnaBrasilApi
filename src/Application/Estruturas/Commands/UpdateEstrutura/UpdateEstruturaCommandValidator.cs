namespace DnaBrasilApi.Application.Estruturas.Commands.UpdateEstrutura;
internal class UpdateEstruturaCommandValidator : AbstractValidator<UpdateEstruturaCommand>
{
    public UpdateEstruturaCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(50)
            .NotEmpty()
            .WithMessage("O Nome é obrigatório.");
        RuleFor(v => v.Descricao)
            .MaximumLength(500);
    }
}
