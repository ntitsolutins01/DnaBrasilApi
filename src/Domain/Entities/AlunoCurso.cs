namespace DnaBrasilApi.Domain.Entities;

public class AlunoCurso : BaseAuditableEntity
{
    public required Aluno Aluno { get; set; }
    public required Curso Curso { get; set; }
    public int Progresso { get; set; }
}
