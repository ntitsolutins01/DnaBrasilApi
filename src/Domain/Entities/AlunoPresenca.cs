namespace DnaBrasilApi.Domain.Entities;

public class AlunoPresenca
{
    public int AlunoId { get; set; }
    public int AtividadeId { get; set; }
    public Aluno? Aluno { get; set; }
    public Atividade? Atividade { get; set; }
    public bool Presenca { get; set; }
    public string? Justificativa { get; set; }
    public DateTime? Data { get; set; }
}
