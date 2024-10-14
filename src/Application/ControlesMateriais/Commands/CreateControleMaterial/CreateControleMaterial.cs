using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesMateriais.Commands.CreateControleMaterial;
public record CreateControleMaterialCommand : IRequest<int>
{
    public required int LinhaAcaoId { get; init; }
    public required string Descricao { get; init; }
    public required string UnidadeMedida { get; init; }
    public required int Quantidade { get; init; }
    public int? Saida { get; init; }
    public int? Disponivel { get; init; }
    public bool Status { get; init; } = true;
}

public class CreateControleMaterialCommandHandler : IRequestHandler<CreateControleMaterialCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateControleMaterialCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateControleMaterialCommand request, CancellationToken cancellationToken)
    {
        var linhaAcao = await _context.LinhasAcoes
            .FindAsync([request.LinhaAcaoId], cancellationToken);

        Guard.Against.NotFound(request.LinhaAcaoId, linhaAcao);

        var entity = new ControleMaterial
        {

            Status = request.Status,
            LinhaAcao = linhaAcao,
            Descricao = request.Descricao,
            UnidadeMedida = request.UnidadeMedida,
            Quantidade = request.Quantidade,
            Saida = request.Saida,
            Disponivel = request.Disponivel
        };

        _context.ControlesMateriais.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
