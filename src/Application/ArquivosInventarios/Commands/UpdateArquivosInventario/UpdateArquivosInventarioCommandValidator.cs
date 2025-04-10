namespace DnaBrasilApi.Application.ArquivosInventarios.Commands.UpdateArquivosInventario;
internal class UpdateArquivosInventarioCommandValidator : AbstractValidator<UpdateArquivosInventarioCommand>
{
    public UpdateArquivosInventarioCommandValidator()
    {
        RuleFor(v => v.NomeArquivo)
            .MaximumLength(50);
    }
}
