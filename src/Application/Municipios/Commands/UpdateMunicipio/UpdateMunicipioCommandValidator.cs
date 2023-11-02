using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Municipios.Commands.UpdateMunicipio;

public class UpdateMunicipioCommandValidator : AbstractValidator<UpdateMunicipioCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateMunicipioCommandValidator(IApplicationDbContext context)
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
