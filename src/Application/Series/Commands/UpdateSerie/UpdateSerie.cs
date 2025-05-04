using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Series.Commands.UpdateSerie;

public record UpdateSerieCommand : IRequest<bool>
{
    public int Id { get; init; }
    public required string Nome { get; init; }
    public required string Turma { get; init; }
    public bool Status { get; init; }
}

public class UpdateSerieCommandHandler : IRequestHandler<UpdateSerieCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateSerieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateSerieCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Series
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Turma = request.Turma;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
