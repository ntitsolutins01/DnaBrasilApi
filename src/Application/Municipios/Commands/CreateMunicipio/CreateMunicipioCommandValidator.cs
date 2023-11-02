using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Municipios.Commands.CreateMunicipio;

public class CreateMunicipioCommandValidator : AbstractValidator<CreateMunicipioCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateMunicipioCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Nome)
            .MaximumLength(100)
            .NotEmpty().NotNull();
        RuleFor(v => v.Codigo)
            .NotNull().NotEmpty();
        RuleFor(v => v.Estado)
            .NotNull().NotEmpty();
    }
}
