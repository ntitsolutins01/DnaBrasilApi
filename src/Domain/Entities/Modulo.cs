namespace DnaBrasil.Domain.Entities;
public class Modulo : BaseAuditableEntity
{
    public required string Nome { get; set; }
    public List<Funcionalidade>? Funcionalidades { get; set;}

}
