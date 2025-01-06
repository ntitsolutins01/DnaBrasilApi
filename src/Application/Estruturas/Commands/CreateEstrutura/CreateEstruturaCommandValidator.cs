
using DnaBrasilApi.Application.Estruturas.Commands.CreateEstrutura;

namespace DnaBrasilApi.Application.Estruturas.Commands.CreateEstrutura;
internal class CreateEstruturaCommandValidator : AbstractValidator<CreateEstruturaCommand>
{
    public CreateEstruturaCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(50)
            .NotEmpty()
            .WithMessage("O Nome é obrigatório.");
        RuleFor(v => v.Descricao)
            .MaximumLength(500);
    }
}
