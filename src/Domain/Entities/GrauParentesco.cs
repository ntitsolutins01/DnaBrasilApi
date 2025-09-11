namespace DnaBrasilApi.Domain.Entities;
public class GrauParentesco : BaseAuditableEntity
{
    public required string Nome { get; set; }
    public bool Status { get; set; } = true;
}
