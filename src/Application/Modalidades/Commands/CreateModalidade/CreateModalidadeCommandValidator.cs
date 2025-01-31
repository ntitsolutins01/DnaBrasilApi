namespace DnaBrasilApi.Application.Modalidades.Commands.CreateModalidade;

public class CreateModalidadeCommandValidator : AbstractValidator<CreateModalidadeCommand>
{
    public CreateModalidadeCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(100)
            .NotNull().NotEmpty();
    }
}
