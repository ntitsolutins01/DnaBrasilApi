namespace DnaBrasil.Domain.Entities;
public class Deficiencia : BaseAuditableEntity
{
    public required string Nome { get; set; }
    public bool Status { get; set; } = true;
    public List<Aluno>? Alunos { get; set; } = new();
}
