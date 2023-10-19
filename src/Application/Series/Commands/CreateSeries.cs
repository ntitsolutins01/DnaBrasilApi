using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;
using DnaBrasil.Domain.Events;

namespace DnaBrasil.Application.Series.Commands;
public record CreateSerieCommand : IRequest<int>
{
    public required string Nome { get; init; }
    public required string Descricao { get; init; }
    public int IdadeInicial { get; init; }
    public int IdadeFinal { get; init; }
    public int ScoreTotal { get; init; }
}

public class CreateSerieCommandHandler : IRequestHandler<CreateSerieCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateSerieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateSerieCommand request, CancellationToken cancellationToken)
    {
        var entity = new Serie
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
            IdadeInicial = request.IdadeInicial,
            IdadeFinal = request.IdadeFinal,
            ScoreTotal = request.ScoreTotal
        };

        _context.Series.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
