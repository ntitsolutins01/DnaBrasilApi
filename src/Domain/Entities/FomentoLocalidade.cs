namespace DnaBrasilApi.Domain.Entities;
public class FomentoLinhaAcao : BaseAuditableEntity
{
    public int FomentoId { get; set; }
    public int LinhaAcaoId { get; set; }
    public required Fomentu Fomento { get; set; }
    public required LinhaAcao LinhaAcao { get; set; }
}
