using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ArquivosInventarios.Commands.CreateArquivosInventario;
public record CreateArquivosInventarioCommand : IRequest<int>
{
    public required int InventarioId { get; set; }
    public string? PathArquivo { get; set; }
    public string? NomeArquivo { get; set; }
}

public class CreateArquivosInventarioCommandHandler : IRequestHandler<CreateArquivosInventarioCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateArquivosInventarioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateArquivosInventarioCommand request, CancellationToken cancellationToken)
    {
        var inventario = await _context.Inventarios
            .FindAsync([request.InventarioId], cancellationToken);

        Guard.Against.NotFound(request.InventarioId, inventario);

        var entity = new ArquivosInventario
        {
            Inventario = inventario,
            PathArquivo = request.PathArquivo,
            NomeArquivo = request.NomeArquivo
        };

        _context.ArquivosInventarios.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
