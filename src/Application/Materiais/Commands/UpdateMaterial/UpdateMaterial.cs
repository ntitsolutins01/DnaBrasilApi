using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Materiais.Commands.UpdateMaterial;

public record UpdateMaterialCommand : IRequest <bool>
{
    public required int Id { get; init; }
    public required int TipoMaterialId { get; set; }
    public required string UnidadeMedida { get; set; }
    public string? Descricao { get; set; }
    public int? QtdAdquirida { get; set; }
}

public class UpdateMaterialCommandHandler : IRequestHandler<UpdateMaterialCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateMaterialCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Materiais
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var tipoMaterial = await _context.TiposMateriais
            .FindAsync([request.TipoMaterialId], cancellationToken);

        Guard.Against.NotFound(request.TipoMaterialId, tipoMaterial);

        entity.TipoMaterial = tipoMaterial;
        entity.UnidadeMedida = request.UnidadeMedida;
        entity.Descricao = request.Descricao;
        entity.QtdAdquirida = request.QtdAdquirida;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
