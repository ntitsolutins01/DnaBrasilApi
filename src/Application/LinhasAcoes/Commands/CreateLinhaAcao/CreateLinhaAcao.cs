using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.LinhasAcoes.Commands.CreateLinhaAcao;

public record CreateLinhaAcaoCommand : IRequest<int>
{
    public required string Nome { get; init; }
    public bool Status { get; init; } = true;
}

public class CreateLinhaAcaoCommandHandler : IRequestHandler<CreateLinhaAcaoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateLinhaAcaoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateLinhaAcaoCommand request, CancellationToken cancellationToken)
    {
        var entity = new LinhaAcao
        {
            Nome = request.Nome,
            Status = request.Status
        };

        _context.LinhasAcoes.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
