namespace DnaBrasil.Domain.Entities;
public class Usuario : BaseAuditableEntity
{
    public required int AspNetUserId { get; set; }
    public required string Nome { get; set; }
    public required string Cpf { get; set; }
    public required string Email { get; set; }
    public required string Telefone { get; set; }
    public required Perfil Perfil { get; set; }
}
