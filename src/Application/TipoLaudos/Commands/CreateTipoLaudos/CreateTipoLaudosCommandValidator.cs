using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Application.TodoItems.Commands.CreateTodoItem;

namespace DnaBrasil.Application.TipoLaudos.Commands.CreateTipoLaudos;
internal class CreateTipoLaudosCommandValidator : AbstractValidator<CreateTipoLaudosCommand>
{
    public CreateTipoLaudosCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.Descricao)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.IdadeInicial)
            .NotEmpty();
        RuleFor(v => v.IdadeFinal)
            .NotEmpty();
        RuleFor(v => v.ScoreTotal)
            .NotEmpty();
    }
}
