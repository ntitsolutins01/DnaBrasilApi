namespace DnaBrasilApi.Domain.Entities;
public class NivelEscolaridade : BaseAuditableEntity
{
    public required string Nome { get; set; }
    public bool Status { get; set; } = true;
}
