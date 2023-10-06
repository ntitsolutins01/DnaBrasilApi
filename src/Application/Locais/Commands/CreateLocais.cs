using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Application.Series.Commands;
using DnaBrasil.Domain.Entities;
using DnaBrasil.Domain.Events;

namespace DnaBrasil.Application.Locais.Commands;
public class CreateLocaisCommand : IRequest<int>
{
    public string? Nome { get; init; }
    public string? Descricao { get; init; }
    public int EstadoId { get; set; }
    public int CidadeId { get; set; }
}

public class CreateLocaisCommandHandler : IRequestHandler<CreateLocaisCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateLocaisCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateLocaisCommand request, CancellationToken cancellationToken)
    {
        var entity = new Local
        {
            Nome = request.Nome,
            Descricao = request.Descricao
        };

        entity.AddDomainEvent(new LocaisCreatedEvent(entity));

        _context.Locais.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
