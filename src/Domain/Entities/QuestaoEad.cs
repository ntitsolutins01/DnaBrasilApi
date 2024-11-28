namespace DnaBrasilApi.Domain.Entities;
public class QuestaoEad : BaseAuditableEntity
{
    public required Aula Aula { get; set; }
    public required string Enunciado { get; set;}
    public string? Referencia { get; set;}
    public required int Questao { get; set;}
    
}
