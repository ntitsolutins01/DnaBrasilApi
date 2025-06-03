namespace DnaBrasilApi.Application.Modalidades.Commands.UpdateModalidade;

public class UpdateModalidadeCommandValidator : AbstractValidator<UpdateModalidadeCommand>
{
    public UpdateModalidadeCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(100)
            .NotEmpty();
    }
}
