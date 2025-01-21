namespace DnaBrasilApi.Domain.Entities;

public class Estrutura : BaseAuditableEntity
{
    public required Localidade Localidade { get; set; }
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public bool Status { get; set; } = true;
}
