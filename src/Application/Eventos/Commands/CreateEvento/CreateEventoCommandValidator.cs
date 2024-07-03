using DnaBrasilApi.Application.Eventos.Commands.CreateEvento;

namespace DnaBrasilApi.Application.Eventos.Commands.CreateEvento;
internal class CreateEventoCommandValidator : AbstractValidator<CreateEventoCommand>
{
    public CreateEventoCommandValidator()
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
