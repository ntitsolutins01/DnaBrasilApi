using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Localidades.Commands.UpdateLocalidade;

public record UpdateLocalidadeCommand : IRequest<bool>
{
    public int Id { get; init; }
    public required string? Nome { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; set; } = true;
    public required Municipio? Municipio { get; init; }
    public required List<Contrato>? Contratos { get; init; }
}

public class UpdateLocalidadeCommandHandler : IRequestHandler<UpdateLocalidadeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateLocalidadeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateLocalidadeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Localidades
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Descricao = request.Descricao;
        entity.Status = request.Status;
        entity.Municipio = request.Municipio;
        entity.Contratos = request.Contratos;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
