using System.ComponentModel.DataAnnotations.Schema;

namespace DnaBrasilApi.Domain.Entities;
public class TalentoEsportivo : BaseAuditableEntity
{
    public required Profissional Profissional { get; set; }
    public Encaminhamento? Encaminhamento { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Flexibilidade { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? PreensaoManual { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Velocidade { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? ImpulsaoHorizontal { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Vo2Max { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Abdominal { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Imc { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? ShuttleRun { get; set; }
    public string? EncaminhamentoTexo { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Altura { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Peso { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Envergadura { get; set; }
    public string? StatusTalentosEsportivos { get; set; }
    public Aluno? Aluno { get; set; }   
}
