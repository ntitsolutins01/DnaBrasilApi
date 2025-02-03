namespace DnaBrasilApi.Domain.Entities;
public class AtividadeAluno
{
    public int AtividadeId { get; set; }
    public int AlunoId { get; set; }
    public Atividade? Atividade { get; set; }
    public Aluno? Aluno { get; set; }
}
