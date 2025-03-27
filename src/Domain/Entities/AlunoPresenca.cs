namespace DnaBrasilApi.Domain.Entities;

public class AlunoPresenca
{
    public int AlunoId { get; set; }
    public int AulaId { get; set; }
    public Aluno? Aluno { get; set; }
    public Aula? Aula { get; set; }
    public bool Presenca { get; set; }
    public string? Justificativa { get; set; }
}
