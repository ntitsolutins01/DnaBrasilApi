using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Fomento.Commands.CreateFomento;
public record CreateFomentoCommand : IRequest<int>
{
    public required string Nome { get; init; }
    public required string Descricao { get; init; }
    public required int IdadeInicial { get; init; }
    public required int IdadeFinal { get; init; }
    public required int ScoreTotal { get; init; }
}

public class CreateFomentoCommandHandler : IRequestHandler<CreateFomentoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateFomentoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateFomentoCommand request, CancellationToken cancellationToken)
    {
        var entity = new Fomento
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
            IdadeInicial = request.IdadeInicial,
            IdadeFinal = request.IdadeFinal,
            ScoreTotal = request.ScoreTotal
        };

        _context.Fomentos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
