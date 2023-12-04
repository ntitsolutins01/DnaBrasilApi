namespace DnaBrasilApi.Application.Fomento.Commands.UpdateFomento;
internal class UpdateFomentoCommandValidator : AbstractValidator<UpdateFomentoCommand>
{
    public UpdateFomentoCommandValidator()
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
