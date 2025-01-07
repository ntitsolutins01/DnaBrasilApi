using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.TiposMateriais.Commands.CreateTipoMaterial;
public record CreateTipoMaterialCommand : IRequest<int>
{
    public required int GrupoMaterialId { get; init; }
    public required String Nome { get; init; }
}

public class CreateTipoMaterialCommandHandler : IRequestHandler<CreateTipoMaterialCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTipoMaterialCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTipoMaterialCommand request, CancellationToken cancellationToken)
    {
        var grupoMaterial = await _context.GruposMateriais
            .FindAsync([request.GrupoMaterialId], cancellationToken);

        Guard.Against.NotFound(request.GrupoMaterialId, grupoMaterial);

        var entity = new TipoMaterial
        {
            GrupoMaterial = grupoMaterial,
            Nome = request.Nome
        };

        _context.TiposMateriais.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
