namespace DnaBrasilApi.Domain.Entities;

public class Material : BaseAuditableEntity
{
    public required TipoMaterial TipoMaterial { get; set; }
    public required String UnidadeMedida { get; set; }
    public String? Descricao { get; set; }
    public int? QtdAdquirida { get; set; }
}
