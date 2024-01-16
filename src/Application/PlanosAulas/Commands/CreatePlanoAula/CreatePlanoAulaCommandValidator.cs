using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.PlanosAulas.Commands.CreatePlanoAula;

public class CreatePlanoAulaCommandValidator : AbstractValidator<CreatePlanoAulaCommand>
{
    private readonly IApplicationDbContext _context;

    public CreatePlanoAulaCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty();
        RuleFor(v => v.Modalidade)
            .MaximumLength(50);
        RuleFor(v => v.TipoEscolaridade)
            .MaximumLength(50)
            .NotEmpty();
        RuleFor(v => v.Url)
            .MaximumLength(500);

    }
}
