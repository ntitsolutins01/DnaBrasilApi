using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Deficiencias.Commands.DeleteEtapaEnsino;

public record DeleteEtapaEnsinoCommand(int Id) : IRequest<bool>;

public class DeleteEtapaEnsinoCommandHandler : IRequestHandler<DeleteEtapaEnsinoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteEtapaEnsinoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteEtapaEnsinoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.EtapasEnsino
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.EtapasEnsino.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
