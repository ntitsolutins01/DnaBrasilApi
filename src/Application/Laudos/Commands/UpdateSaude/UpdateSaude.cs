using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Laudos.Commands.UpdateSaude;

public record UpdateSaudeCommand : IRequest
{
    public int Id { get; init; }
    public int? Altura { get; init; }
    public int Massa { get; init; }
    public int? Envergadura { get; init; }
}

public class UpdateSaudeCommandHandler : IRequestHandler<UpdateSaudeCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateSaudeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateSaudeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Saudes
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Altura = request.Altura;
        entity.Massa = request.Massa;
        entity.Envergadura = request.Envergadura;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
