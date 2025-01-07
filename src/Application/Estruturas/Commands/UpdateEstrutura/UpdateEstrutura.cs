using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Estruturas.Commands.UpdateEstrutura;

public record UpdateEstruturaCommand : IRequest <bool>
{
    public required int Id { get; init; }
    public required int LocalidadeId { get; init; }
    public required string Nome { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; init; }
}

public class UpdateEstruturaCommandHandler : IRequestHandler<UpdateEstruturaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateEstruturaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateEstruturaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Estruturas
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var localidade = await _context.Localidades
            .FindAsync([request.LocalidadeId], cancellationToken);

        Guard.Against.NotFound(request.LocalidadeId, localidade);
        
        entity.Localidade = localidade;
        entity.Nome = request.Nome;
        entity.Descricao = request.Descricao;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
