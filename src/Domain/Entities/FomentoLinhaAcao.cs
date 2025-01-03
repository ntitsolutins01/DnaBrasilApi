namespace DnaBrasilApi.Domain.Entities;
public class FomentoLocalidade : BaseAuditableEntity
{
    public int FomentoId { get; set; }
    public int LocalidadeId { get; set; }
    public Fomentu? Fomento { get; set; }
    public Localidade? Localidade { get; set; }
}
