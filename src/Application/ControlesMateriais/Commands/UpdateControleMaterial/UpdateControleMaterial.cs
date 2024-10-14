using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesMateriais.Commands.UpdateControleMaterial;

public record UpdateControleMaterialCommand : IRequest<bool>
{
    public required int Id { get; init; }
    public required string Descricao { get; init; }
    public required string UnidadeMedida { get; init; }
    public required int Quantidade { get; init; }
    public int? Saida { get; init; }
    public int? Disponivel { get; init; }
    public bool Status { get; init; }
}

public class UpdateControleMaterialCommandHandler : IRequestHandler<UpdateControleMaterialCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateControleMaterialCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateControleMaterialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ControlesMateriais
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound<ControleMaterial>(request.Id.ToString(), entity);

        entity.Descricao = request.Descricao;
        entity.UnidadeMedida = request.UnidadeMedida;
        entity.Quantidade = request.Quantidade;
        entity.Saida = request.Saida;
        entity.Disponivel = request.Disponivel;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
