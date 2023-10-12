namespace DnaBrasil.Domain.Entities;
public class Local : BaseAuditableEntity
{
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public bool Status { get; set; } =  true;
    public Municipio? Municipio { get; set; }
}
