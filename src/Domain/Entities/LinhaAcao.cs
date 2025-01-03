namespace DnaBrasilApi.Domain.Entities;
public class LinhaAcao : BaseAuditableEntity
{
    public required string Nome { get; set; }
    public bool Status { get; set; }
    public IList<FomentoLinhaAcao>? FomentoLinhasAcoes { get; set; }
}
