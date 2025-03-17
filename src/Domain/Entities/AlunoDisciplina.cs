namespace DnaBrasilApi.Domain.Entities;

public class AlunoDisciplina
{
    public int AlunoId { get; set; }
    public int DisciplinaId { get; set; }
    public Aluno? Aluno { get; set; }
    public Disciplina? Disciplina { get; set; }
}
