using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Perfis.Commands.UpdatePerfil;

public record UpdatePerfilCommand : IRequest<bool>
{
    public int Id { get; init; }
    public required string Nome { get; set; }
    public required string? Descricao { get; set; }
}

public class UpdatePerfilCommandHandler : IRequestHandler<UpdatePerfilCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdatePerfilCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdatePerfilCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Perfis
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Descricao = request.Descricao;
        
        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
