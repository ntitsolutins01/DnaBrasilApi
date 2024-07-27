namespace DnaBrasilApi.Application.Laudos.Commands.UpdateVocacional;

public class UpdateVocacionalCommandValidator : AbstractValidator<UpdateVocacionalCommand>
{
    public UpdateVocacionalCommandValidator()
    {
        RuleFor(v => v.Resposta)
            .MaximumLength(100)
            .NotEmpty();
    }
}
