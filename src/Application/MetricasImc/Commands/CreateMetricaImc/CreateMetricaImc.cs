using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.MetricasImc.Commands.CreateMetricaImc;

public record CreateMetricaImcCommand : IRequest<int>
{
    public int? Idade { get; set; }
    public string? Sexo { get; set; }
    public string? Classificacao{ get; init; }
    public decimal ValorInicial{ get; init; }
    public decimal ValorFinal { get; init; }
    public bool Status { get; init; } = true;
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
        var entity = new MetricaImc
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
