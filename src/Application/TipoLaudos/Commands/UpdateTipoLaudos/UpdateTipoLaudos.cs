using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.TipoLaudos.Commands.UpdateTipoLaudo;

public record UpdateTipoLaudoCommand : IRequest
{
    public required int Id { get; init; }
    public required string? Nome { get; init; }
    public required string? Descricao { get; init; }
}

public class UpdateTipoLaudoCommandHandler : IRequestHandler<UpdateTipoLaudoCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTipoLaudoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateTipoLaudoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TipoLaudos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Descricao = request.Descricao;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
