using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Locais.Commands.UpdateLocal;

public record UpdateLocalCommand : IRequest
{
    public int Id { get; init; }
    public required string? Nome { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; set; } = true;
    public required Municipio? Municipio { get; init; }
    public required List<Contrato>? Contratos { get; init; }
}

public class UpdateLocalCommandHandler : IRequestHandler<UpdateLocalCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateLocalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateLocalCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Locais
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Descricao = request.Descricao;
        entity.Status = request.Status;
        entity.Municipio = request.Municipio;
        entity.Contratos = request.Contratos;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
