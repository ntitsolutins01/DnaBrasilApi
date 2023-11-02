namespace DnaBrasil.Domain.Entities;
public class Funcionalidade : BaseAuditableEntity
{
    public required string Nome { get; set; }
    public Modulo? Modulo { get; set;}
}
