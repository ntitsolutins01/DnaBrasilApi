using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using DnaBrasilApi.Domain.Events;

namespace DnaBrasilApi.Application.TipoLaudos.Commands.CreateTipoLaudos;
public record CreateTipoLaudosCommand : IRequest<int>
{
    public required string? Nome { get; init; }
    public required string? Descricao { get; init; }
}

public class CreateTipoLaudosCommandHandler : IRequestHandler<CreateTipoLaudosCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTipoLaudosCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTipoLaudosCommand request, CancellationToken cancellationToken)
    {
        var entity = new TipoLaudo
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
        };

        _context.TipoLaudos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
