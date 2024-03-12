using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.MetricasImc.Commands.CreateMetricaImc;

public record CreateMetricaImcCommand : IRequest<int>
{
    public string? Sexo { get; set; }
    public int? Idade { get; set; }
    public string? Classificacao { get; set; }
    public decimal ValorInicial { get; set; }
    public decimal ValorFinal { get; set; }
    public bool Status { get; set; } = true;
}

public class CreateMetricaImcCommandHandler : IRequestHandler<CreateMetricaImcCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateMetricaImcCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateMetricaImcCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.MetricasImc
        {
            Idade = request.Idade,
            Sexo = request.Sexo,
            Classificacao = request.Classificacao,
            ValorInicial = request.ValorInicial,
            ValorFinal = request.ValorFinal,
            Status = request.Status
        };

        _context.MetricasImc.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
