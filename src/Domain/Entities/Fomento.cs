namespace DnaBrasilApi.Domain.Entities;
public class Profissional : BaseAuditableEntity
{
    public required string Nome { get; set; }
    public bool Status { get; set; } = true;
    public Municipio? Municipio { get; set; }
    public Localidade? Localidade { get; set; }
}
