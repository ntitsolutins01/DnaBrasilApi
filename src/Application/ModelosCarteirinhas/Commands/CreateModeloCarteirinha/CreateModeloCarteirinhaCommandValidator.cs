namespace DnaBrasilApi.Application.ModelosCarteirinhas.Commands.CreateModeloCarteirinha;

public class CreateModeloCarteirinhaCommandValidator : AbstractValidator<CreateModeloCarteirinhaCommand>
{
    public CreateModeloCarteirinhaCommandValidator()
    {
        RuleFor(v => v.NomeImagem)
            .MaximumLength(70);
        RuleFor(v => v.UrlImagem)
            .MaximumLength(150);
    }
}
