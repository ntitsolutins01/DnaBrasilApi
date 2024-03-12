namespace DnaBrasilApi.Domain.Entities;
public class MetricasImc : BaseAuditableEntity
{
    public string? Sexo { get; init; }
    public int? Idade { get; init; }
    public string? Classificacao { get; init; }
    public decimal ValorInicial { get; init; }
    public decimal ValorFinal { get; init; }
    public bool Status { get; init; } = true;
}
