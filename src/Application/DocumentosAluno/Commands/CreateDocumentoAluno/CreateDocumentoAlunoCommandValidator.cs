namespace DnaBrasilApi.Application.DocumentosAluno.Commands.CreateDocumentoAluno;
internal class CreateDocumentoAlunoCommandValidator : AbstractValidator<CreateDocumentoAlunoCommand>
{
    public CreateDocumentoAlunoCommandValidator()
    {
        RuleFor(v => v.NomeDocumento)
            .MaximumLength(250)
            .NotEmpty()
            .WithMessage("O nome do arquivo é obrigatório.");
        RuleFor(v => v.Url)
            .MaximumLength(500)
            .WithMessage("A url do arquivo é obrigatória.");
    }
}
