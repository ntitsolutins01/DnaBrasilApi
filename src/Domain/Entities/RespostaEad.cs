using System.ComponentModel.DataAnnotations.Schema;

namespace DnaBrasilApi.Domain.Entities;
public class RespostaEad : BaseAuditableEntity
{
    public required string RespostaQuestionarioEad { get; set;}
    public required QuestionarioEad QuestionarioEad { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public required decimal ValorPesoRespostaEad { get; set; }

}
