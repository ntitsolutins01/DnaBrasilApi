using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.ConsumosAlimentares.Commands.UpdateConsumoAlimentar;

public record UpdateConsumoAlimentarCommand : IRequest
{
    public int Id { get; init; }
    public required Profissional Profissional { get; init; }
    public required Questionario Questionario { get; init; }
    public required string Resposta { get; init; }
}

public class UpdateConsumoAlimentarCommandHandler : IRequestHandler<UpdateConsumoAlimentarCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateConsumoAlimentarCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateConsumoAlimentarCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ConsumoAlimentares
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Profissional = request.Profissional;
        entity.Resposta = request.Resposta;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
