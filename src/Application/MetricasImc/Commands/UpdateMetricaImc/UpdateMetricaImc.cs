using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.MetricasImc.Commands.UpdateMetricaImc;

public record UpdateMetricaImcCommand : IRequest<bool>
{
    public int Id { get; init; }
    public int? TipoLaudoId { get; init; }
    public int? Idade { get; set; }
    public string? Sexo { get; set; }
    public string? Classificacao { get; init; }
    public decimal ValorInicial { get; init; }
    public decimal ValorFinal { get; init; }
    public bool Status { get; init; }
}

public class UpdateMetricaImcCommandHandler : IRequestHandler<UpdateMetricaImcCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateMetricaImcCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateMetricaImcCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.MetricasImc
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Idade = request.Idade;
        entity.Sexo = request.Sexo; 
        entity.Classificacao = request.Classificacao;
        entity.ValorInicial = request.ValorInicial;
        entity.ValorFinal = request.ValorFinal;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
