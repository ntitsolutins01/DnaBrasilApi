using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasilApi.Application.TodoItems.Commands.CreateTodoItem;

namespace DnaBrasilApi.Application.TipoLaudos.Commands.CreateTipoLaudos;
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
    }
}
