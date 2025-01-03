﻿namespace DnaBrasilApi.Application.TextosLaudos.Commands.UpdateTextoLaudo;

public class UpdateTextoLaudoCommandValidator : AbstractValidator<UpdateTextoLaudoCommand>
{
    public UpdateTextoLaudoCommandValidator()
    {

        RuleFor(v => v.Aviso)
            .MaximumLength(100);
        RuleFor(v => v.Texto)
            .MaximumLength(500);
        RuleFor(v => v.Classificacao)
            .MaximumLength(100);
        RuleFor(v => v.Sexo)
            .MaximumLength(1);
    }
}
