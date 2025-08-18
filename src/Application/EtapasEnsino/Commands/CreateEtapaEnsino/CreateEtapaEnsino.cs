using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.EtapasEnsino.Commands.CreateEtapaEnsino;

public record CreateEtapaEnsinoCommand : IRequest<int>
{
    public required string Nome { get; init; }
    public bool Status { get; set; } = true;
}

public class CreateEtapaEnsinoCommandHandler : IRequestHandler<CreateEtapaEnsinoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateEtapaEnsinoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateEtapaEnsinoCommand request, CancellationToken cancellationToken)
    {
        var entity = new EtapaEnsino
        {
            Nome = request.Nome
        };

        _context.EtapasEnsino.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
