using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Commands.UpdateSaude;

public record UpdateSaudeCommand : IRequest <bool>
{
    public required int Id { get; init; }
    public required decimal EnvergaduraSaude { get; init; }
    public required decimal MassaCorporalSaude { get; init; }
    public required decimal AlturaSaude { get; init; }
    public required string StatusSaude { get; init; }
}

public class UpdateSaudeCommandHandler : IRequestHandler<UpdateSaudeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateSaudeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateSaudeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Saudes
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Altura = request.AlturaSaude;
        entity.Massa = request.MassaCorporalSaude;
        entity.Envergadura = request.EnvergaduraSaude;
        entity.StatusSaude = request.StatusSaude;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
