using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Municipios.Commands.UpdateMunicipio;

public record UpdateMunicipioCommand : IRequest
{
    public int Id { get; init; }
    public required int Codigo { get; init; }
    public required string? Nome { get; init; }
    public required Estado? Estado { get; init; }
}

public class UpdateMunicipioCommandHandler : IRequestHandler<UpdateMunicipioCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateMunicipioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateMunicipioCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Municipios
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Codigo = request.Codigo;
        entity.Nome = request.Nome;
        entity.Estado = request.Estado;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
