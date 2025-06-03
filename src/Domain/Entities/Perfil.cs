namespace DnaBrasilApi.Domain.Entities;
public class Perfil : BaseAuditableEntity
{
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public required string AspNetRoleId { get; set; }
    public bool Status { get; set; } = true;
    public bool Ead { get; set; } = false;
}
