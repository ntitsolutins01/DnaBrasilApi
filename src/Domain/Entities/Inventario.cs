namespace DnaBrasilApi.Domain.Entities;

public class Inventario : BaseAuditableEntity
{
    public required Material Material { get; set; }
    public required Localidade Localidade { get; set; }
    public int? Quantidade { get; set; }
    public required string Motivo { get; set; }
}
