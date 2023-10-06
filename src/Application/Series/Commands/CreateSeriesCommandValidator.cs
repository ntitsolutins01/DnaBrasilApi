using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Application.TipoLaudos.Commands.CreateTipoLaudos;

namespace DnaBrasil.Application.Series.Commands;
internal class CreateSeriesCommandValidator : AbstractValidator<CreateSeriesCommand>
{
    public CreateSeriesCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.Descricao)
            .MaximumLength(200)
            .NotEmpty();
    }
}
