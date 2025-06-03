using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesMateriaisEstoquesSaidas.Commands.CreateControleMaterialEstoqueSaida;
public record CreateControleMaterialEstoqueSaidaCommand : IRequest<int>
{
    public required int MunicipioId { get; set; }
    public required int LocalidadeId { get; set; }
    public required int InventarioId { get; set; }
    public required int Quantidade { get; set; }
    public required int ProfissionalId { get; set; }
}

public class CreateControleMaterialEstoqueSaidaCommandHandler : IRequestHandler<CreateControleMaterialEstoqueSaidaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateControleMaterialEstoqueSaidaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateControleMaterialEstoqueSaidaCommand request, CancellationToken cancellationToken)
    {
        var municipio = await _context.Municipios
            .FindAsync([request.MunicipioId], cancellationToken);

        Guard.Against.NotFound(request.MunicipioId, municipio);

        var localidade = await _context.Localidades
            .FindAsync([request.LocalidadeId], cancellationToken);

        Guard.Against.NotFound(request.LocalidadeId, localidade);

        var inventario = await _context.Inventarios
            .FindAsync([request.InventarioId], cancellationToken);

        Guard.Against.NotFound(request.InventarioId, inventario);

        var profissional = await _context.Usuarios
            .FindAsync([request.ProfissionalId], cancellationToken);

        Guard.Against.NotFound(request.ProfissionalId, profissional);

        var entity = new ControleMaterialEstoqueSaida
        {
            Municipio = municipio,
            Localidade = localidade,
            Inventario = inventario,
            Quantidade = request.Quantidade,
            Usuario = profissional
        };

        _context.ControlesMateriaisEstoquesSaidas.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
