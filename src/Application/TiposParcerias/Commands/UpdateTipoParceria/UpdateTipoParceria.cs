using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TiposParcerias.Commands.UpdateTipoParceria;

public record UpdateTipoParceriaCommand : IRequest<bool>
{
    public int Id { get; init; }
    public required string Nome { get; init; }
    public required int Parceria { get; init; }
    public bool Status { get; init; }
}

public class UpdateTipoParceriaCommandHandler : IRequestHandler<UpdateTipoParceriaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateTipoParceriaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateTipoParceriaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TiposParcerias
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Parceria = request.Parceria;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
