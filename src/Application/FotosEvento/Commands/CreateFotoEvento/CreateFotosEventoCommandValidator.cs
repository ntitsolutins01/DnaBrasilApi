namespace DnaBrasilApi.Application.FotosEvento.Commands.CreateFotoEvento;
internal class CreateFotosEventoCommandValidator : AbstractValidator<CreateFotoEventoCommand>
{
    public CreateFotosEventoCommandValidator()
    {
        RuleFor(v => v.NomeArquivo)
            .MaximumLength(250)
            .NotEmpty()
            .WithMessage("O nome do arquivo é obrigatório.");
        RuleFor(v => v.Url)
            .MaximumLength(500)
            .WithMessage("A url do arquivo é obrigatória.");
    }
}
