using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Materiais.Commands.UpdateMaterial;

public record UpdateMaterialCommand : IRequest <bool>
{
    public required int Id { get; init; }
    public required string UnidadeMedida { get; init; }
    public required string Descricao { get; init; }
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

        entity.UnidadeMedida = request.UnidadeMedida;
        entity.Descricao = request.Descricao;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
