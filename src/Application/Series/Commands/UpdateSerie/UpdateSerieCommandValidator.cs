namespace DnaBrasilApi.Application.Series.Commands.UpdateSerie;
internal class UpdateSerieCommandValidator : AbstractValidator<UpdateSerieCommand>
{
    public UpdateSerieCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty();
        RuleFor(v => v.Turma)
            .MaximumLength(100)
            .NotEmpty();
    }
}
