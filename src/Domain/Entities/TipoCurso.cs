namespace DnaBrasilApi.Domain.Entities;

public class TipoCurso : BaseAuditableEntity
{
    public required string Nome { get; set; }
    public bool Status { get; set; } = true;
}
