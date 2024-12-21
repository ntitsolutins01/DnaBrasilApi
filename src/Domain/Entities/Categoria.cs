namespace DnaBrasilApi.Domain.Entities;

public class Categoria : BaseAuditableEntity
{
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public bool Status { get; set; } = true;
}
