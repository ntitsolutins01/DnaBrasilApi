﻿namespace DnaBrasilApi.Application.Ambientes.Commands.CreateAmbiente;

public class CreateAmbienteCommandValidator : AbstractValidator<CreateAmbienteCommand>
{
    public CreateAmbienteCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(100)
            .NotNull().NotEmpty();
        RuleFor(v => v.Profissionais)
            .NotNull();
        RuleFor(v => v.Alunos)
            .NotNull();
        RuleFor(v => v.Status)
            .NotNull().NotEmpty();
    }
}
