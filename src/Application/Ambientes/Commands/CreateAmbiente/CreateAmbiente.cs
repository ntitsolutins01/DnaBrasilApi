using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Ambientes.Commands.CreateAmbiente;

public record CreateAmbienteCommand : IRequest<int>
{
    public required string Nome { get; init; }
    public bool Status { get; init; } = true;
}

public class CreateAmbienteCommandHandler : IRequestHandler<CreateAmbienteCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAmbienteCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAmbienteCommand request, CancellationToken cancellationToken)
    {
        var entity = new Ambiente
        {
            Nome = request.Nome,
            Status = request.Status
        };

        q_context.Ambientes.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
