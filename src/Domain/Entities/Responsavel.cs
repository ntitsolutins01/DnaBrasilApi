namespace DnaBrasilApi.Domain.Entities;

public class Responsavel : BaseAuditableEntity
{
    public required string Nome { get; set; }
    public required string Cpf { get; set; }
    public required string Telefone { get; set; }
    public string? Email { get; set; }
    public required GrauParentesco GrauParentesco { get; set; }
    public bool Status { get; set; } = true;
}
