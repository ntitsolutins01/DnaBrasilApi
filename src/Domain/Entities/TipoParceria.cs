namespace DnaBrasilApi.Domain.Entities;
public class TipoParceria : BaseAuditableEntity
{
    public string? Nome { get; set; }
    public int? Parceria { get; set; }
    public bool Status { get; set; }
}
