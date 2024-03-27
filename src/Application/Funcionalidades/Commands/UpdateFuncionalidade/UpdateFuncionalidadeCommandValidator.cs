namespace DnaBrasilApi.Application.Funcionalidades.Commands.UpdateFuncionalidade;

public class UpdateFuncionalidadeCommandValidator : AbstractValidator<UpdateFuncionalidadeCommand>
{
    public UpdateFuncionalidadeCommandValidator()
    {

        RuleFor(v => v.Nome)
            .MaximumLength(200);
    }
}
