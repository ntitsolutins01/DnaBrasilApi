using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Usuarios.Commands.UpdateUsuario;

public record UpdateUsuarioCommand : IRequest<bool>
{
    public int Id { get; init; }
    public required string Nome { get; init; }
    public required string Email { get; init; }
    public int PerfilId { get; init; }
    public bool Status { get; init; }
}

public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateUsuarioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Usuarios
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var perfil = await _context.Perfis.Where(x => x.Id == request.PerfilId).FirstOrDefaultAsync();

        entity.Nome = request.Nome;
        entity.Email = request.Email;
        entity.Status = request.Status;
        entity.Perfil = perfil;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
