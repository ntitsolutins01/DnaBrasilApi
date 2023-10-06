using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Application.Series.Commands;

namespace DnaBrasil.Application.Locais.Commands;
internal class CreateLocaisCommandValidator : AbstractValidator<CreateLocaisCommand>
{
    public CreateLocaisCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.Descricao)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.EstadoId)
            .NotEmpty();
        RuleFor(v => v.CidadeId)
            .NotEmpty();
    }
}
