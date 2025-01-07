using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.GruposMateriais.Commands.UpdateGrupoMaterial;

public record UpdateGrupoMaterialCommand : IRequest <bool>
{
    public required int Id { get; init; }
    public required string Nome { get; init; }
}

public class UpdateGrupoMaterialCommandHandler : IRequestHandler<UpdateGrupoMaterialCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateGrupoMaterialCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateGrupoMaterialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.GruposMateriais
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
