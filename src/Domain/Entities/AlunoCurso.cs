namespace DnaBrasilApi.Domain.Entities;

public class AlunoCurso
{
    public int AlunoId { get; set; }
    public int CursoId { get; set; }
    public Aluno? Aluno { get; set; }
    public Curso? Curso { get; set; }
    public int Progresso { get; set; }
}
