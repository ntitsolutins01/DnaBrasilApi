using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.EtapasEnsino.Commands.UpdateEtapaEnsino;

public record UpdateEtapaEnsinoCommand : IRequest<bool>
{
    public int Id { get; init; }
    public required string Nome { get; init; }
    public bool Status { get; init; }
}

public class UpdateEtapaEnsinoCommandHandler : IRequestHandler<UpdateEtapaEnsinoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateEtapaEnsinoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateEtapaEnsinoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.EtapasEnsino
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
