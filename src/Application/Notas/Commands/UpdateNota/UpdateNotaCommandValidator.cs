namespace DnaBrasilApi.Application.Notas.Commands.UpdateNota;
internal class UpdateNotaCommandValidator : AbstractValidator<UpdateNotaCommand>
{
    public UpdateNotaCommandValidator()
    {
        RuleFor(x => x.PrimeiroBimestre)
            .PrecisionScale(2, 10, false);
        RuleFor(v => v.SegundoBimestre)
            .PrecisionScale(2, 10, false); ;
        RuleFor(v => v.TerceiroBimestre)
            .PrecisionScale(2, 10, false); ;
        RuleFor(v => v.QuartoBimestre)
            .PrecisionScale(2, 10, false); ;
        RuleFor(v => v.Media)
            .PrecisionScale(2, 10, false); ;
    }
}
