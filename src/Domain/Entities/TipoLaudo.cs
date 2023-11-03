namespace DnaBrasil.Domain.Entities;

public class TipoLaudo : BaseAuditableEntity
{
    public required string? Nome { get; set; }
    public required string? Descricao { get; set; }
}
