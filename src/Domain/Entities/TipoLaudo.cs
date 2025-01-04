namespace DnaBrasilApi.Domain.Entities;

public class TipoLaudo : BaseAuditableEntity
{
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public bool Status { get; set; } = true;
    public required int IdadeMinima { get; set; }
}
