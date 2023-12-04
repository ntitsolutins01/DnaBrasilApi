namespace DnaBrasilApi.Domain.Entities;
public class Fomentu : BaseAuditableEntity
{
    public required string Nome { get; set; }
    public bool Status { get; set; } = true;
    public required Municipio? Municipio { get; set; }
    public required Localidade Localidade { get; set; }
}
