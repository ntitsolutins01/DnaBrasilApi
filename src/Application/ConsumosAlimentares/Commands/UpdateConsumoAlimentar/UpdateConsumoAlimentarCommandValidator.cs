﻿using DnaBrasil.Application.Laudos.Commands.UpdateConsumoAlimentar;

namespace DnaBrasil.Application.ConsumosAlimentares.Commands.UpdateConsumoAlimentar;

public class UpdateConsumoAlimentarCommandValidator : AbstractValidator<UpdateConsumoAlimentarCommand>
{
    public UpdateConsumoAlimentarCommandValidator()
    {
        RuleFor(v => v.Resposta)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.Aluno)
            .NotEmpty();
        RuleFor(v => v.Profissional)
            .NotEmpty();
    }
}
