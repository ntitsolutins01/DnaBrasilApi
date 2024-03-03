using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.TiposParcerias.Commands.CreateTipoParceria;

public record CreateTipoParceriaCommand : IRequest<int>
{
    public required string Nome { get; init; }
    public required int Parceria { get; init; }
    public bool Status { get; init; } = true;
}

public class CreateTipoParceriaCommandHandler : IRequestHandler<CreateTipoParceriaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTipoParceriaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTipoParceriaCommand request, CancellationToken cancellationToken)
    {
        var entity = new TipoParceria
        {
            Nome = request.Nome,
            Parceria = request.Parceria,
            Status = request.Status
        };

        _context.TiposParcerias.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
