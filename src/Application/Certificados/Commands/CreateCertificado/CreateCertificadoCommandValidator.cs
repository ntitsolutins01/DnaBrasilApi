namespace DnaBrasilApi.Application.Certificados.Commands.CreateCertificado;
internal class CreateCertificadoCommandValidator : AbstractValidator<CreateCertificadoCommand>
{
    public CreateCertificadoCommandValidator()
    {
        RuleFor(v => v.HtmlFrente)
            .MaximumLength(2000)
            .NotEmpty()
            .WithMessage("O html é obrigatório.");
        RuleFor(v => v.HtmlVerso)
            .MaximumLength(2000)
            .NotEmpty()
            .WithMessage("O html é obrigatório.");
        RuleFor(v => v.NomeImagemFrente)
            .MaximumLength(100)
            .WithMessage("O tamanho máximo é 100.");
        RuleFor(v => v.NomeImagemVerso)
            .MaximumLength(100)
            .WithMessage("O tamanho máximo é 100.");
    }
}
