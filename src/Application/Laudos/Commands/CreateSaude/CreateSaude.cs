using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Commands.CreateSaude;

public record CreateSaudeCommand : IRequest<int>
{
    public int? ProfissionalId { get; init; }
    public int? EnvergaduraSaude { get; init; }
    public int? MassaCorporalSaude { get; init; }
    public int? AlturaSaude { get; init; }
    public string? StatusSaude { get; init; }
}

public class CreateSaudeCommandHandler : IRequestHandler<CreateSaudeCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateSaudeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateSaudeCommand request, CancellationToken cancellationToken)
    {

        Profissional? profissional = null;

        if (request.ProfissionalId != null)
        {
            profissional = await _context.Profissionais
                .FindAsync([request.ProfissionalId!], cancellationToken);

            Guard.Against.NotFound((int)request.ProfissionalId!, profissional);
        }

        var entity = new Saude
        {
            Profissional = profissional,
            Altura = request.AlturaSaude,
            Massa = request.MassaCorporalSaude,
            Envergadura = request.EnvergaduraSaude,
            StatusSaude = request.StatusSaude
        };

        _context.Saudes.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
