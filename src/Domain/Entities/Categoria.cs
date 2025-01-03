namespace DnaBrasilApi.Domain.Entities;

public class Categoria : BaseAuditableEntity
{
    public required string Codigo { get; set; }
    public required string Nome { get; set; }
    public required int IdadeInicial { get; set; }
    public required int IdadeFinal { get; set; }
    public string? Descricao { get; set; }
    public bool Status { get; set; } = true;
}
