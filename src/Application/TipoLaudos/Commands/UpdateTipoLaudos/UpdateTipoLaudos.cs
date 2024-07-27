using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TipoLaudos.Commands.UpdateTipoLaudos;

public record UpdateTipoLaudoCommand : IRequest <bool>
{
    public required int Id { get; init; }
    public required string Nome { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; init; }
}

public class UpdateTipoLaudoCommandHandler : IRequestHandler<UpdateTipoLaudoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateTipoLaudoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateTipoLaudoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TipoLaudos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Descricao = request.Descricao;
        entity.Status = request.Status;

        await _context.SaveChangesAsync(cancellationToken);
        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
