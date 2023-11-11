﻿using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Localidades.Commands.CreateLocalidade;

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
        RuleFor(v => v.Status)
            .NotNull().NotEmpty();
        RuleFor(v => v.Municipio)
            .NotNull();
        RuleFor(v => v.Contratos)
            .NotNull();
    }
}