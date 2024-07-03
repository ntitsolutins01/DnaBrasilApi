using DnaBrasilApi.Application.Notas.Commands.CreateNota;

namespace DnaBrasilApi.Application.Notas.Commands.CreateNota;
internal class CreateNotaCommandValidator : AbstractValidator<CreateNotaCommand>
{
    public CreateNotaCommandValidator()
    {
        RuleFor(x => x.PrimeiroBimestre)
            .PrecisionScale(2, 10, false)
            .LessThan(0).WithMessage("Nota não pode ser negativa")
            .GreaterThan(10).WithMessage("Nota não pode ser maior que 10");
        RuleFor(v => v.SegundoBimestre)
            .PrecisionScale(2, 10, false)
            .LessThan(0).WithMessage("Nota não pode ser negativa")
            .GreaterThan(10).WithMessage("Nota não pode ser maior que 10");
        RuleFor(v => v.TerceiroBimestre)
            .PrecisionScale(2, 10, false)
            .LessThan(0).WithMessage("Nota não pode ser negativa")
            .GreaterThan(10).WithMessage("Nota não pode ser maior que 10");
        RuleFor(v => v.QuartoBimestre)
            .PrecisionScale(2, 10, false)
            .LessThan(0).WithMessage("Nota não pode ser negativa")
            .GreaterThan(10).WithMessage("Nota não pode ser maior que 10");
        RuleFor(v => v.Media)
            .PrecisionScale(2, 10, false)
            .LessThan(0).WithMessage("Nota não pode ser negativa")
            .GreaterThan(10).WithMessage("Nota não pode ser maior que 10");
    }
}
