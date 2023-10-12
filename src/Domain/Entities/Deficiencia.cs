namespace DnaBrasil.Domain.Entities;
public class Deficiencia : BaseAuditableEntity
{
    public string? Nome { get; set; }
    public bool Status { get; set; }
    public List<Aluno> Alunos { get; } = new();
}
