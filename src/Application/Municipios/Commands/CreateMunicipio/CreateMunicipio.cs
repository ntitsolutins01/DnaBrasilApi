using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Municipios.Commands.CreateMunicipio;
public record CreateMunicipioCommand : IRequest<int>
{
    public required int Codigo { get; init; }
    public required string? Nome { get; init; }
    public required Estado? Estado { get; init; }
}

public class CreateMunicipioCommandHandler : IRequestHandler<CreateMunicipioCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateMunicipioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateMunicipioCommand request, CancellationToken cancellationToken)
    {
        var entity = new Municipio
        {
            Codigo = request.Codigo,
            Nome = request.Nome,
            Estado = request.Estado
        };

        _context.Municipios.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
