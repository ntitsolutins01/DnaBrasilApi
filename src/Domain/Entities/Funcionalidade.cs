namespace DnaBrasil.Domain.Entities;
public class Funcionalidade : BaseAuditableEntity
{
    public required string Nome { get; set; }
    public required Modulo Modulo { get; set;}
}
