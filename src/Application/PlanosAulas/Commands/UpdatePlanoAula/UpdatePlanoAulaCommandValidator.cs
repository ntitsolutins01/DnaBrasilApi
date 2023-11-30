using System.Text.RegularExpressions;
using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.PlanosAulas.Commands.UpdatePlanoAula;

public class UpdatePlanoAulaCommandValidator : AbstractValidator<UpdatePlanoAulaCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdatePlanoAulaCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty();
        RuleFor(v => v.Grade)
            .MaximumLength(150)
            .NotEmpty();
        RuleFor(v => v.Url)
            .MaximumLength(150)
            .NotEmpty();
    }

}