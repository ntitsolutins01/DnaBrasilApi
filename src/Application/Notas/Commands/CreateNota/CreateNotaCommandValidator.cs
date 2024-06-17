using DnaBrasilApi.Application.Notas.Commands.CreateNota;

namespace DnaBrasilApi.Application.Notas.Commands.CreateNota;
internal class CreateNotaCommandValidator : AbstractValidator<CreateNotaCommand>
{
    public CreateNotaCommandValidator()
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
