using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Inventarios.Commands.CreateInventario;
public record CreateInventarioCommand : IRequest<int>
{
    public required int MaterialId { get; set; }
    public required int LocalidadeId { get; set; }
    public int? Quantidade { get; set; }
    public required string Motivo { get; set; }
}

public class CreateInventarioCommandHandler : IRequestHandler<CreateInventarioCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateInventarioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateInventarioCommand request, CancellationToken cancellationToken)
    {
        var material = await _context.Materiais
            .FindAsync([request.MaterialId], cancellationToken);

        Guard.Against.NotFound(request.MaterialId, material);

        var localidade = await _context.Localidades
            .FindAsync([request.LocalidadeId], cancellationToken);

        Guard.Against.NotFound(request.LocalidadeId, localidade);

        var entity = new Inventario
        {
            Material = material,
            Localidade = localidade,
            Quantidade = request.Quantidade,
            Motivo = request.Motivo
        };

        _context.Inventarios.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
