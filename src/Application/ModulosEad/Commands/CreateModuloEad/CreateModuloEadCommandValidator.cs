﻿using DnaBrasilApi.Application.ModulosEad.Commands.CreateModuloEad;

namespace DnaBrasilApi.Application.ModulosEad.Commands.CreateModuloEad;
internal class CreateModuloEadCommandValidator : AbstractValidator<CreateModuloEadCommand>
{
    public CreateModuloEadCommandValidator()
    {
        RuleFor(v => v.Titulo)
            .MaximumLength(250)
            .NotEmpty()
            .WithMessage("O título é obrigatório.");
        RuleFor(v => v.Descricao)
            .MaximumLength(500)
            .WithMessage("A quantidade máxima de caracteres permitidos são de 500.");
        RuleFor(v => v.CargaHoraria)
            .GreaterThan(0)
            .WithMessage("A carga horária deve ser maior que zero.")
            .NotEmpty()
            .WithMessage("A carga horária é obrigatória.");
    }
}
