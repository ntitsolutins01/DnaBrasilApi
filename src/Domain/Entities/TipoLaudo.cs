namespace DnaBrasil.Domain.Entities;

public class TipoLaudo : BaseAuditableEntity
{
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public int IdadeInicial { get; set; }
    public int IdadeFinal { get; set; }
    public int ScoreTotal { get; set; }
}
