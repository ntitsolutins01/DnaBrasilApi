using System.ComponentModel.DataAnnotations.Schema;

namespace DnaBrasilApi.Domain.Entities;
public class MetricaImc : BaseAuditableEntity
{
    public string? Sexo { get; set; }
    public int? Idade { get; set; }
    public string? Classificacao { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal ValorInicial { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal ValorFinal { get; set; }
    public bool Status { get; set; } = true;
}
