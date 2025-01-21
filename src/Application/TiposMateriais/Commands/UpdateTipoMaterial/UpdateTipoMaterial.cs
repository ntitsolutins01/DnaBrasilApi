using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TiposMateriais.Commands.UpdateTipoMaterial;

public record UpdateTipoMaterialCommand : IRequest <bool>
{
    public required int Id { get; init; }
    public required string Nome { get; init; }
}

public class UpdateTipoMaterialCommandHandler : IRequestHandler<UpdateTipoMaterialCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateTipoMaterialCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateTipoMaterialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TiposMateriais
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
