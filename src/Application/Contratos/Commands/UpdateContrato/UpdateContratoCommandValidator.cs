namespace DnaBrasil.Application.Contratos.Commands.UpdateContrato;
internal class UpdateContratoCommandValidator : AbstractValidator<UpdateContratoCommand>
{
    public UpdateContratoCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(80)
            .NotEmpty();
        RuleFor(v => v.Descricao)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.DtIni)
            .InclusiveBetween(new DateTime(1900, 01, 01), new DateTime(2050, 01, 01))
            .WithMessage("'{PropertyName}' deve ser maior que 01/01/1980 e menor que 01/01/2050.")
            .NotEmpty();
        RuleFor(v => v.DtFim)
            .InclusiveBetween(new DateTime(1900, 01, 01), new DateTime(2050, 01, 01))
            .WithMessage("'{PropertyName}' deve ser maior que 01/01/1980 e menor que 01/01/2050.")
            .NotEmpty();
        RuleFor(v => v.Anexo)
            .MaximumLength(500)
            .NotEmpty();

    }
}
