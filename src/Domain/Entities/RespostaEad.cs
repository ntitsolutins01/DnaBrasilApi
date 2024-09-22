using System.ComponentModel.DataAnnotations.Schema;

namespace DnaBrasilApi.Domain.Entities;
public class RespostaEad : BaseAuditableEntity
{
    public required QuestaoEad Questao { get; set; }
    public required string TipoResposta { get; set;}
    public string? TipoAlternativa { get; set;}
    public required string Resposta { get; set;}
    [Column(TypeName = "decimal(10,2)")]
    public required decimal ValorPesoResposta { get; set; }

}
