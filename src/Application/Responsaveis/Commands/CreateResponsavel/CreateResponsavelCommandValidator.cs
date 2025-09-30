using DnaBrasilApi.Application.Responsaveis.Commands.CreateResponsavel;

namespace DnaBrasilApi.Application.Responsavels.Commands.CreateResponsavel;
internal class CreateResponsavelCommandValidator : AbstractValidator<CreateResponsavelCommand>
{
    public CreateResponsavelCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty();
    }
}
