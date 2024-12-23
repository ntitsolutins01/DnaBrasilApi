using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Materiais.Commands.CreateMaterial;
public record CreateMaterialCommand : IRequest<int>
{
    public required int TipoMaterialId { get; set; }
    public required String UnidadeMedida { get; set; }
    public String? Descricao { get; set; }
    public int? QtdAdquirida { get; set; }
}

public class CreateMaterialCommandHandler : IRequestHandler<CreateMaterialCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateMaterialCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
    {
        var tipoMaterial = await _context.TiposMateriais
            .FindAsync([request.TipoMaterialId], cancellationToken);

        Guard.Against.NotFound(request.TipoMaterialId, tipoMaterial);

        var entity = new Material
        {
            TipoMaterial = tipoMaterial,
            UnidadeMedida = request.UnidadeMedida,
            Descricao = request.Descricao,
            QtdAdquirida = request.QtdAdquirida
        };

        _context.Materiais.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
