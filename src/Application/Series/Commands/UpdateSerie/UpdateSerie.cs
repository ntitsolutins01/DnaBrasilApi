using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Series.Commands.UpdateSerie;

public record UpdateSerieCommand : IRequest
{
    public int Id { get; init; }
    public required string Nome { get; init; }
    public required string Descricao { get; init; }
    public required int IdadeInicial { get; init; }
    public required int IdadeFinal { get; init; }
    public required int ScoreTotal { get; init; }
}

public class UpdateSerieCommandHandler : IRequestHandler<UpdateSerieCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateSerieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateSerieCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Series
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Descricao = request.Descricao;
        entity.IdadeInicial = request.IdadeInicial;
        entity.IdadeFinal = request.IdadeFinal;
        entity.ScoreTotal = request.ScoreTotal;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
