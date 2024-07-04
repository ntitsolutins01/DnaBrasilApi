namespace DnaBrasilApi.Domain.Entities;

public class Evento : BaseAuditableEntity
{
   public required Localidade Localidade { get; set; }
   public required string Titulo { get; set; }
   public string? Descricao { get; set; }
   public required DateTime DataEvento { get; set; }
   public List<ControlePresenca>? ControlesPresencas { get; set; }
   public bool Status { get; set; } = true;
}
