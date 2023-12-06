namespace DnaBrasilApi.Application.Fomentos.Commands.UpdateFomento;
internal class UpdateFomentoCommandValidator : AbstractValidator<UpdateFomentoCommand>
{
    public UpdateFomentoCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty();

    }
}
