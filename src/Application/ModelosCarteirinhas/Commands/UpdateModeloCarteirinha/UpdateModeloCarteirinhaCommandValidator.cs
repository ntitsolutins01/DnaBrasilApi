namespace DnaBrasilApi.Application.ModelosCarteirinhas.Commands.UpdateModeloCarteirinha;

public class UpdateModeloCarteirinhaCommandValidator : AbstractValidator<UpdateModeloCarteirinhaCommand>
{
    public UpdateModeloCarteirinhaCommandValidator()
    {
        RuleFor(v => v.NomeImagem)
            .MaximumLength(70);
        RuleFor(v => v.UrlImagem)
            .MaximumLength(150);
    }
}
