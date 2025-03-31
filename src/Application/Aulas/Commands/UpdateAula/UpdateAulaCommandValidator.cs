namespace DnaBrasilApi.Application.Aulas.Commands.UpdateAula;
internal class UpdateAulaCommandValidator : AbstractValidator<UpdateAulaCommand>
{
    public UpdateAulaCommandValidator()
    {
        RuleFor(v => v.Titulo)
            .MaximumLength(250)
            .NotEmpty()
            .WithMessage("O título é obrigatório.");
        RuleFor(v => v.Descricao)
            .MaximumLength(500)
            .WithMessage("A quantidade máxima de caracteres permitidos são de 500.");
    }
}
