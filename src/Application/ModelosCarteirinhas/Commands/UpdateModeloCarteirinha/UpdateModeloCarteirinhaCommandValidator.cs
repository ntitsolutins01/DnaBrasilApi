namespace DnaBrasilApi.Application.ModelosCarteirinhas.Commands.UpdateModeloCarteirinha;

public class UpdateModeloCarteirinhaCommandValidator : AbstractValidator<UpdateModeloCarteirinhaCommand>
{
    public UpdateModeloCarteirinhaCommandValidator()
    {
        RuleFor(v => v.NomeImagemFrente)
            .MaximumLength(70);
        RuleFor(v => v.UrlImagemFrente)
            .MaximumLength(150);
        RuleFor(v => v.NomeImagemVerso)
            .MaximumLength(70);
        RuleFor(v => v.UrlImagemVerso)
            .MaximumLength(150);
    }
}
