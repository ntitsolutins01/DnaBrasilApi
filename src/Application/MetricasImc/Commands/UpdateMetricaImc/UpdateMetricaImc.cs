using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.MetricasImc.Commands.UpdateMetricaImc;

public record UpdateMetricaImcCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string? Sexo { get; set; }
    public int? Idade { get; set; }
    public string? Classificacao { get; set; }
    public decimal ValorInicial { get; set; }
    public decimal ValorFinal { get; set; }
    public bool Status { get; set; } = true;
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
