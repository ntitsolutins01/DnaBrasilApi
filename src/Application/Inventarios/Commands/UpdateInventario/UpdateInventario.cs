using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Inventarios.Commands.UpdateInventario;

public record UpdateInventarioCommand : IRequest<bool>
{
    public required int Id { get; init; }
    public int? Quantidade { get; init; }
    public required string Motivo { get; init; }
}

public class UpdateInventarioCommandHandler : IRequestHandler<UpdateInventarioCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateInventarioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateInventarioCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Inventarios
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Quantidade = request.Quantidade;
        entity.Motivo = request.Motivo;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
