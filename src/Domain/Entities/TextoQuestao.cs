using System.ComponentModel.DataAnnotations.Schema;

namespace DnaBrasilApi.Domain.Entities;
public class TextoQuestao : BaseAuditableEntity
{
    public required QuestaoEad QuestaoEad { get; set; }
    public string? Texto { get; set; }
    public Byte[]? Imagem { get; set; }
}
