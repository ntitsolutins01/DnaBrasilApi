using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Application.Ambientes.Commands.UpdateAmbiente;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Ambientes.Commands.UpdateAmbiente;

public record UpdateAmbienteCommand : IRequest
{
    public int Id { get; init; }
    public string? Nome { get; init; }
    public bool Status { get; init; }
}

public class UpdateAmbienteCommandHandler : IRequestHandler<UpdateAmbienteCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateAmbienteCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateAmbienteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Ambientes
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Status = request.Status;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
