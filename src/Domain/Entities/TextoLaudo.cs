using System.ComponentModel.DataAnnotations.Schema;

namespace DnaBrasilApi.Domain.Entities;
public class TextoLaudo : BaseAuditableEntity
{
    public required TipoLaudo TipoLaudo { get; set; }
    public int? Idade { get; set; }
    public string? Sexo { get; set; }
    public required string Classificacao { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? PontoInicial { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? PontoFinal { get; set; }
    public required string Aviso { get; set; }
    public required string Texto { get; set; }
    public int? Quadrante { get; set; }
    public bool Status { get; set; } = true;
}
