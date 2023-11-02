namespace DnaBrasil.Domain.Entities;

public class TipoLaudo : BaseAuditableEntity
{
    public required string? Nome { get; set; }
    public required string? Descricao { get; set; }
    public required int IdadeInicial { get; set; }
    public required int IdadeFinal { get; set; }
    public required int ScoreTotal { get; set; }
    public required bool Status  { get; set; } = true;
}
