using System.ComponentModel.DataAnnotations.Schema;

namespace DnaBrasilApi.Domain.Entities;
public class Saude : BaseAuditableEntity
{
    public Profissional? Profissional { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Altura { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Massa { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Envergadura { get; set; }
    public string? StatusSaude { get; set; }
    public Aluno? Aluno { get; set; }
}
