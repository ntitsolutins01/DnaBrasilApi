using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesMensaisEstoque.Commands.CreateControleMensalEstoque;

public record CreateControleMensalEstoqueCommand : IRequest<int>
{
    public required int MaterialId { get; set; }
    public int? QtdPrevista { get; set; }
    public DateTime? DataMesSaida { get; set; }
    public int? TotalSaidas { get; set; }
    public int? TotalEstoque { get; set; }
    public int? QtdMateriaisDanificadosExtraviados { get; set; }
    public string? JustificativaDanificadosExtraviados { get; set; }
    public DateTime? DataDanificadosExtraviados { get; set; }
}

public class CreateControleMensalEstoqueCommandHandler : IRequestHandler<CreateControleMensalEstoqueCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateControleMensalEstoqueCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateControleMensalEstoqueCommand request, CancellationToken cancellationToken)
    {
        var material = await _context.Materiais
            .FindAsync([request.MaterialId], cancellationToken);

        Guard.Against.NotFound(request.MaterialId, material);

        var entity = new ControleMensalEstoque
        {
            Material = material,
            QtdPrevista = request.QtdPrevista,
            DataMesSaida = request.DataMesSaida,
            TotalSaidas = request.TotalSaidas,
            TotalEstoque = request.TotalEstoque,
            QtdMateriaisDanificadosExtraviados = request.QtdMateriaisDanificadosExtraviados,
            JustificativaDanificadosExtraviados = request.JustificativaDanificadosExtraviados,
            DataDanificadosExtraviados = request.DataDanificadosExtraviados
        };

        _context.ControlesMensaisEstoque.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
