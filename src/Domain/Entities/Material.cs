namespace DnaBrasilApi.Domain.Entities;

public class Material : BaseAuditableEntity
{
    public Localidade? Localidade { get; set; }
    public required TipoMaterial TipoMaterial { get; set; }
    public required string UnidadeMedida { get; set; }
    public string? Descricao { get; set; }
    public int? QtdAdquirida { get; set; }
}
