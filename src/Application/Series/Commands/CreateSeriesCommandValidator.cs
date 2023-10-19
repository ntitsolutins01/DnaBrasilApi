using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Application.TipoLaudos.Commands.CreateTipoLaudos;

namespace DnaBrasil.Application.Series.Commands;
internal class CreateSeriesCommandValidator : AbstractValidator<CreateSerieCommand>
{
    public CreateSeriesCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty();
        RuleFor(v => v.Descricao)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.Descricao)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.IdadeInicial)
            .InclusiveBetween(5, 18)
            .WithMessage("'{PropertyName}' deve ser maior 5 e menor que 18.")
            .NotEmpty();
        RuleFor(v => v.IdadeFinal)
            .InclusiveBetween(5, 18)
            .WithMessage("'{PropertyName}' deve ser maior 5 e menor que 18.")
            .NotEmpty();
        RuleFor(v => v.ScoreTotal)
            .InclusiveBetween(0, 1000)
            .WithMessage("'{PropertyName}' deve ser maior 0 e menor que 1000.")
            .NotEmpty();

    }
}
