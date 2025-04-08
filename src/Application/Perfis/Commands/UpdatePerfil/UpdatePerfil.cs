using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Perfis.Commands.UpdatePerfil;

public record UpdatePerfilCommand : IRequest<bool>
{
    public int Id { get; init; }
    public required string Nome { get; init; }
    public required string? Descricao { get; init; }
    public bool Status { get; init; }
    public bool Ead { get; init; }
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
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Descricao = request.Descricao;
        entity.Status = request.Status;
        entity.Ead = request.Ead;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
