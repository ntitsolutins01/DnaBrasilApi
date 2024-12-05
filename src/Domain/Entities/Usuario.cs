namespace DnaBrasilApi.Domain.Entities;

public class Usuario : BaseAuditableEntity
{
    public required string AspNetUserId { get; set; } 
    public required string Nome { get; set; }
    public required string CpfCnpj { get; set; }
    public required string TipoPessoa { get; set; }
    public required string Email { get; set; }
    public required string AspNetRoleId { get; set; }
    public required Perfil Perfil { get; set; }
    public bool? Status { get; set; } = true;
    public Municipio? Municipio { get; set; }
    public Localidade? Localidade { get; set; }
}
