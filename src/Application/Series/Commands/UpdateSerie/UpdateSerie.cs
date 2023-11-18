using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Series.Commands.UpdateSerie;

public record UpdateSerieCommand : IRequest <bool>
{
    public int Id { get; init; }
    public required string Nome { get; init; }
    public required string Descricao { get; init; }
    public required int IdadeInicial { get; init; }
    public required int IdadeFinal { get; init; }
    public required int ScoreTotal { get; init; }
}

public class UpdateSerieCommandHandler : IRequestHandler<UpdateSerieCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateSerieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateSerieCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Series
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Descricao = request.Descricao;
        entity.IdadeInicial = request.IdadeInicial;
        entity.IdadeFinal = request.IdadeFinal;
        entity.ScoreTotal = request.ScoreTotal;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
