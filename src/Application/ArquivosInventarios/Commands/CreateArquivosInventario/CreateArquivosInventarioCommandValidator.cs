namespace DnaBrasilApi.Application.ArquivosInventarios.Commands.CreateArquivosInventario;
internal class CreateArquivosInventarioCommandValidator : AbstractValidator<CreateArquivosInventarioCommand>
{
    public CreateArquivosInventarioCommandValidator()
    {
        RuleFor(v => v.NomeArquivo)
            .MaximumLength(80);
    }
}
