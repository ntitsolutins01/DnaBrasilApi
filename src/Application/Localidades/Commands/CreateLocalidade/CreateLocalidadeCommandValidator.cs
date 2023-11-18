using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Localidades.Commands.CreateLocalidade;

public class CreateLocalidadeCommandValidator : AbstractValidator<CreateLocalidadeCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateLocalidadeCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty().NotNull();
        RuleFor(v => v.Descricao)
            .MaximumLength(300);
        //RuleFor(v => v.Municipio)
        //    .NotNull();
        //RuleFor(v => v.Contratos)
        //    .NotNull();
    }
}
