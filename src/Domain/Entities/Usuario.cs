namespace DnaBrasilApi.Domain.Entities;

public class Usuario : BaseAuditableEntity
{
    public required string AspNetUserId { get; set; } 
    public required string Nome { get; set; }
    public required string Cpf { get; set; }
    public required string Email { get; set; }
    public required string AspNetRoleId { get; set; }
    public required Perfil Perfil { get; set; }
    public bool? Status { get; set; } = true;
}
