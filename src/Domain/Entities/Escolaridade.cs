namespace DnaBrasilApi.Domain.Entities;
public class Escolaridade : BaseAuditableEntity
{
    public required string Nome { get; set; }
    public bool Status { get; set; } = true;
    public string? Descricao { get; set; }
}
