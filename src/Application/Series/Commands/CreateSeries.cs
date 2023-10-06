using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;
using DnaBrasil.Domain.Events;

namespace DnaBrasil.Application.Series.Commands;
public record CreateSeriesCommand : IRequest<int>
{
    public string? Nome { get; init; }
    public string? Descricao { get; init; }
    public int IdadeInicial { get; init; }
    public int IdadeFinal { get; init; }
    public int ScoreTotal { get; init; }
}

public class CreateSeriesCommandHandler : IRequestHandler<CreateSeriesCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateSeriesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateSeriesCommand request, CancellationToken cancellationToken)
    {
        var entity = new Serie
        {
            Nome = request.Nome,
            Descricao = request.Descricao
        };

        _context.Series.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
