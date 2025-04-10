namespace DnaBrasilApi.Domain.Entities;

public class Material : BaseAuditableEntity
{
    public required TipoMaterial TipoMaterial { get; set; }
    public required string UnidadeMedida { get; set; }
    public required string Descricao { get; set; }
}
