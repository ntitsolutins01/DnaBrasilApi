namespace DnaBrasilApi.Application.Provas.Commands.CreateProva;
internal class CreateProvaCommandValidator : AbstractValidator<CreateProvaCommand>
{
    public CreateProvaCommandValidator()
    {
        RuleFor(v => v.Titulo)
            .MaximumLength(250)
            .NotEmpty()
            .WithMessage("O título é obrigatório.");
    }
}
