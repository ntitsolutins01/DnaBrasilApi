namespace DnaBrasilApi.Application.Certificados.Commands.CreateCertificado;
internal class CreateCertificadoCommandValidator : AbstractValidator<CreateCertificadoCommand>
{
    public CreateCertificadoCommandValidator()
    {
        RuleFor(v => v.Url)
            .MaximumLength(2000)
            .NotEmpty()
            .WithMessage("A url é obrigatória.");
        RuleFor(v => v.Nome)
            .MaximumLength(100)
            .WithMessage("O tamanho máximo é 100.");
    }
}
