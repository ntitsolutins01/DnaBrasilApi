using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Estruturas.Commands.CreateEstrutura;
public record CreateEstruturaCommand : IRequest<int>
{
    public required int LocalidadeId { get; init; }
    public required string Nome { get; init; }
    public string? Descricao { get; init; }
}

public class CreateEstruturaCommandHandler : IRequestHandler<CreateEstruturaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateEstruturaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateEstruturaCommand request, CancellationToken cancellationToken)
    {
        var localidade = await _context.Localidades
            .FindAsync([request.LocalidadeId], cancellationToken);

        Guard.Against.NotFound(request.LocalidadeId, localidade);

        var entity = new Estrutura
        {
            Localidade = localidade,
            Nome = request.Nome,
            Descricao = request.Descricao
        };

        _context.Estruturas.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
