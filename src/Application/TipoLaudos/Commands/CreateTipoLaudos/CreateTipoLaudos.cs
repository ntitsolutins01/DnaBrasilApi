using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;
using DnaBrasil.Domain.Events;

namespace DnaBrasil.Application.TipoLaudos.Commands.CreateTipoLaudos;
public record CreateTipoLaudosCommand : IRequest<int>
{
    public required string? Nome { get; init; }
    public required string? Descricao { get; init; }
    public required int IdadeInicial { get; init; }
    public required int IdadeFinal { get; init; }
    public required int ScoreTotal { get; init; }
    public required bool Status { get; init; } = true;
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
            IdadeInicial = request.IdadeInicial,
            IdadeFinal = request.IdadeFinal,
            ScoreTotal = request.ScoreTotal,
            Status = request.Status
        };

        _context.TipoLaudos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
