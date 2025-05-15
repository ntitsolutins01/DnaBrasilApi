namespace DnaBrasilApi.Application.Certificados.Commands.UpdateCertificado;
internal class UpdateCertificadoCommandValidator : AbstractValidator<UpdateCertificadoCommand>
{
    public UpdateCertificadoCommandValidator()
    {
        RuleFor(v => v.HtmlFrente)
            .MaximumLength(2000)
            .NotEmpty()
            .WithMessage("O html é obrigatório.");
        RuleFor(v => v.HtmlVerso)
            .MaximumLength(2000)
            .NotEmpty()
            .WithMessage("O html é obrigatório.");
    }
}
