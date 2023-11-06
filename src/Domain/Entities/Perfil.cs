namespace DnaBrasil.Domain.Entities;
public class Perfil : BaseAuditableEntity
{
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
}
