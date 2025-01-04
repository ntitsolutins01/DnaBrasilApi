using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesMateriaisEstoquesSaidas.Commands.UpdateControleMaterialEstoqueSaida;

public record UpdateControleMaterialEstoqueSaidaCommand : IRequest <bool>
{
    public required int Id { get; set; }
    public required int MaterialId { get; set; }
    public required int Quantidade { get; set; }
    public String? Solicitante { get; set; }
}

public class UpdateControleMaterialEstoqueSaidaCommandHandler : IRequestHandler<UpdateControleMaterialEstoqueSaidaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateControleMaterialEstoqueSaidaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateControleMaterialEstoqueSaidaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ControlesMateriaisEstoquesSaidas
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var material = await _context.Materiais
            .FindAsync([request.MaterialId], cancellationToken);

        Guard.Against.NotFound(request.MaterialId, material);

        entity.Material = material;
        entity.Quantidade = request.Quantidade;
        entity.Solicitante = request.Solicitante;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
