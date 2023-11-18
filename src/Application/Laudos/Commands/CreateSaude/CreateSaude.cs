using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Commands.CreateSaude;

public record CreateSaudeCommand : IRequest<int>
{
    public required Profissional Profissional { get; init; }
    public int? Altura { get; init; }
    public int Massa { get; init; }
    public int? Envergadura { get; init; }
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
        var entity = new Saude
        {
            Profissional = request.Profissional,
            Altura = request.Altura,
            Massa = request.Massa,
            Envergadura = request.Envergadura
        };

        _context.Saudes.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
