using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesMensaisEstoque.Commands.UpdateControleMensalEstoque;

public record UpdateControleMensalEstoqueCommand : IRequest <bool>
{
    public required int Id { get; set; }
    public required int MaterialId { get; set; }
    public int? QtdPrevista { get; set; }
    public DateTime? DataMesSaida { get; set; }
    public int? TotalSaidas { get; set; }
    public int? TotalEstoque { get; set; }
    public int? QtdMateriaisDanificadosExtraviados { get; set; }
    public string? JustificativaDanificadosExtraviados { get; set; }
    public DateTime? DataDanificadosExtraviados { get; set; }
}

public class UpdateControleMensalEstoqueCommandHandler : IRequestHandler<UpdateControleMensalEstoqueCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateControleMensalEstoqueCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateControleMensalEstoqueCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ControlesMensaisEstoque
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var material = await _context.Materiais
            .FindAsync([request.MaterialId], cancellationToken);

        Guard.Against.NotFound(request.MaterialId, material);

        entity.Material = material;
        entity.QtdPrevista = request.QtdPrevista;
        entity.DataMesSaida = request.DataMesSaida;
        entity.TotalSaidas = request.TotalSaidas;
        entity.TotalEstoque = request.TotalEstoque;
        entity.QtdMateriaisDanificadosExtraviados = request.QtdMateriaisDanificadosExtraviados;
        entity.JustificativaDanificadosExtraviados = request.JustificativaDanificadosExtraviados;
        entity.DataDanificadosExtraviados = request.DataDanificadosExtraviados;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
