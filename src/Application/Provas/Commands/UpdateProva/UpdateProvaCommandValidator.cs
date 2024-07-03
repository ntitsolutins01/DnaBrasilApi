namespace DnaBrasilApi.Application.Provas.Commands.UpdateProva;
internal class UpdateProvaCommandValidator : AbstractValidator<UpdateProvaCommand>
{
    public UpdateProvaCommandValidator()
    {
        RuleFor(v => v.Titulo)
            .MaximumLength(250)
            .NotEmpty()
            .WithMessage("O título é obrigatório.");
    }
}
