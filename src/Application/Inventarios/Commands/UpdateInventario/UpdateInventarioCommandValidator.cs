namespace DnaBrasilApi.Application.Inventarios.Commands.UpdateInventario;
internal class UpdateInventarioCommandValidator : AbstractValidator<UpdateInventarioCommand>
{
    public UpdateInventarioCommandValidator()
    {
        RuleFor(v => v.Quantidade)
            .GreaterThanOrEqualTo(0)
            .WithMessage("A quantidade não pode ser menor que 0.");
        RuleFor(v => v.Motivo)
            .NotEmpty()
            .MaximumLength(1000);
    }
}
