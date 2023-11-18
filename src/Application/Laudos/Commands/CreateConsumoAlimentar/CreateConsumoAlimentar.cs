using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Commands.CreateConsumoAlimentar;

public record CreateConsumoAlimentarCommand : IRequest<int>
{
    public required Profissional Profissional { get; init; }
    public required Questionario Questionario { get; init; }
    public required string Resposta { get; init; }
}

public class CreateConsumoAlimentarCommandHandler : IRequestHandler<CreateConsumoAlimentarCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateConsumoAlimentarCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateConsumoAlimentarCommand request, CancellationToken cancellationToken)
    {
        var entity = new ConsumoAlimentar
        {
            Profissional = request.Profissional,
            Questionario = request.Questionario,
            Resposta = request.Resposta
        };

        _context.ConsumoAlimentares.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
