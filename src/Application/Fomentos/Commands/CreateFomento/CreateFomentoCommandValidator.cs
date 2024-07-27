namespace DnaBrasilApi.Application.Fomentos.Commands.CreateFomento;
internal class CreateFomentoCommandValidator : AbstractValidator<CreateFomentoCommand>
{
    public CreateFomentoCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty();
        RuleFor(v => v.MunicipioId)
            .NotNull();
        RuleFor(v => v.LocalidadeId)
            .NotNull();
    }
}
