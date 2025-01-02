using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesMateriaisEstoquesSaidas.Commands.CreateControleMaterialEstoqueSaida;
public record CreateControleMaterialEstoqueSaidaCommand : IRequest<int>
{
    public required int MaterialId { get; set; }
    public required int Quantidade { get; set; }
    public string? Solicitante { get; set; }
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
        var material = await _context.Materiais
            .FindAsync([request.MaterialId], cancellationToken);

        Guard.Against.NotFound(request.MaterialId, material);

        var entity = new ControleMaterialEstoqueSaida
        {
            Material = material,
            Quantidade = request.Quantidade,
            Solicitante = request.Solicitante
        };

        _context.ControlesMateriaisEstoquesSaidas.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
