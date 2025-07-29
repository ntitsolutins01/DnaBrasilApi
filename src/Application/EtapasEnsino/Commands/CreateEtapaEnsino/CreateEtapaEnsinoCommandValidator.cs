using DnaBrasilApi.Application.EtapasEnsino.Commands.CreateEtapaEnsino;

namespace DnaBrasilApi.Application.Deficiencias.Commands.CreateEtapaEnsino;

public class CreateEtapaEnsinoCommandValidator : AbstractValidator<CreateEtapaEnsinoCommand>
{
    public CreateEtapaEnsinoCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(80)
            .NotEmpty();
    }
}
