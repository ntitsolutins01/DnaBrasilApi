using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Commands.UpdateSaude;

public record UpdateSaudeCommand : IRequest <bool>
{
    public int Id { get; init; }
    public decimal? Altura { get; init; }
    public decimal? Massa { get; init; }
    public decimal? Envergadura { get; init; }
    public string? StatusSaude { get; set; }
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
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Altura = request.Altura;
        entity.Massa = request.Massa;
        entity.Envergadura = request.Envergadura;
        entity.StatusSaude = request.StatusSaude;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
