namespace DnaBrasilApi.Application.Eventos.Commands.UpdateEvento;
internal class UpdateEventoCommandValidator : AbstractValidator<UpdateEventoCommand>
{
    public UpdateEventoCommandValidator()
    {
        RuleFor(v => v.Titulo)
            .MaximumLength(250)
            .NotEmpty()
            .WithMessage("O título é obrigatório.");
        RuleFor(v => v.Descricao)
            .MaximumLength(500)
            .WithMessage("A Descrição é obrigatória.");
    }
}
