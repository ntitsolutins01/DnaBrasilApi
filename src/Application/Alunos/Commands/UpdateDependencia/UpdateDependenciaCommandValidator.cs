﻿using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Dependencias.Commands.UpdateDependencia;

namespace DnaBrasilApi.Application.Alunos.Commands.UpdateDependencia;

public class UpdateDependenciaCommandValidator : AbstractValidator<UpdateDependenciaCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateDependenciaCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        //RuleFor(v => v.Doencas)
        //    .MaximumLength(150)
        //    .NotEmpty();
        //RuleFor(v => v.Nacionalidade)
        //    .MaximumLength(150)
        //    .NotEmpty();
        //RuleFor(v => v.Naturalidade)
        //    .MaximumLength(150)
        //    .NotEmpty();
        //RuleFor(v => v.NomeEscola)
        //    .MaximumLength(150)
        //    .NotEmpty();
        //RuleFor(v => v.TipoEscola)
        //    .NotEmpty();
        //RuleFor(v => v.TipoEscolaridade)
        //    .NotEmpty();
        //RuleFor(v => v.Turno)
        //    .MaximumLength(150)
        //    .NotEmpty();
        //RuleFor(v => v.Serie)
        //    .MaximumLength(150)
        //    .NotEmpty();
        //RuleFor(v => v.Ano)
        //    .MaximumLength(150)
        //    .NotEmpty();
        //RuleFor(v => v.Turma)
        //    .MaximumLength(150)
        //    .NotEmpty();
    }
}
