using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.GruposMateriais.Commands.CreateGrupoMaterial;
public record CreateGrupoMaterialCommand : IRequest<int>
{
    public required string Nome{ get; init; }
}

public class CreateGrupoMaterialCommandHandler : IRequestHandler<CreateGrupoMaterialCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateGrupoMaterialCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateGrupoMaterialCommand request, CancellationToken cancellationToken)
    {
        var entity = new GrupoMaterial
        {
            Nome = request.Nome
        };

        _context.GruposMateriais.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
