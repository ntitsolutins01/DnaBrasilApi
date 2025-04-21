namespace DnaBrasilApi.Domain.Entities;

public class AlunoAula
{
    public int AlunoId { get; set; }
    public int AulaId { get; set; }
    public Aluno? Aluno { get; set; }
    public Aula? Aula { get; set; }
    public int Progresso { get; set; }
}
