using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Perfis.Commands.CreatePerfil;

public record CreatePerfilCommand : IRequest<int>
{
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public required string AspNetRoleId { get; set; }
}

public class CreatePerfilCommandHandler : IRequestHandler<CreatePerfilCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreatePerfilCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePerfilCommand request, CancellationToken cancellationToken)
    {
        var entity = new Perfil
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
            AspNetRoleId = request.AspNetRoleId
        };

        _context.Perfis.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
