using System.ComponentModel.DataAnnotations.Schema;

namespace DnaBrasilApi.Domain.Entities;

public class Nota : BaseAuditableEntity
{
   public required Aluno Aluno { get; set; }

   public required Disciplina Disciplina { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? PrimeiroBimestre { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? SegundoBimestre { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? TerceiroBimestre { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? QuartoBimestre { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? Media { get; set; }

    public bool Status { get; set; } = true;
}
