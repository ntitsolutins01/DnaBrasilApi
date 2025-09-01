namespace DnaBrasilApi.Domain.Entities;
public class TextoImagemQuestao : BaseAuditableEntity
{
    public required QuestaoEad QuestaoEad { get; set; }
    public int Ordem { get; set; }
    public string? Tipo { get; set; }
    public string? TextoImagem { get; set; }
}
