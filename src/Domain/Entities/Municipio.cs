namespace DnaBrasilApi.Domain.Entities;
public class Municipio : BaseAuditableEntity
{
    public required int CodigoIbge { get; set; }
    public required string? Nome { get; set; }
    public required Estado? Estado { get; set; }
}
