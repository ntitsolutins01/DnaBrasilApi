namespace DnaBrasilApi.Domain.Entities;
public class FomentoLocalidade : BaseAuditableEntity
{
    public int FomentoId { get; set; }
    public int LocalidadeId { get; set; }
    public required Fomentu Fomento { get; set; }
    public required Localidade Localidade { get; set; }
}
