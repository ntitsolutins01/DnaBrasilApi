using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Series.Commands.CreateSerie;
public record CreateSerieCommand : IRequest<int>
{
    public required string Nome { get; init; }
    public required string Descricao { get; init; }
    public required int IdadeInicial { get; init; }
    public required int IdadeFinal { get; init; }
    public required int ScoreTotal { get; init; }
    public bool Status { get; init; } = true;
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
            ScoreTotal = request.ScoreTotal,
            Status = request.Status
        };

        _context.Series.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
