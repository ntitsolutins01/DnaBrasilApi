﻿using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Locais.CreateLocal;

public class CreateLocalCommandValidator : AbstractValidator<CreateLocalCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateLocalCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty();
        RuleFor(v => v.Descricao)
            .MaximumLength(300)
            .NotEmpty();
        RuleFor(v => v.Status)
            .NotNull().NotEmpty();
    }
}
