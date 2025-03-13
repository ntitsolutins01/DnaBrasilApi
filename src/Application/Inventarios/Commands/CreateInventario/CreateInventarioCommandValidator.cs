namespace DnaBrasilApi.Application.Inventarios.Commands.CreateInventario;
internal class CreateInventarioCommandValidator : AbstractValidator<CreateInventarioCommand>
{
    public CreateInventarioCommandValidator()
    {
        RuleFor(v => v.Quantidade)
            .GreaterThanOrEqualTo(0)
            .WithMessage("A quantidade não pode ser menor que 0.");
    }
}
