namespace DnaBrasilApi.Application.Responsaveis.Commands.UpdateResponsavel;
internal class UpdateResponsavelCommandValidator : AbstractValidator<UpdateResponsavelCommand>
{
    public UpdateResponsavelCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty();
    }
}
