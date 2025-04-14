namespace DnaBrasilApi.Domain.Entities;
public class ControleFrequencia : BaseAuditableEntity
{
    public required Aluno Aluno { get; set; }
    public required Disciplina Disciplina { get; set; }
    public string? Presenca { get; set; }
    public string? Justificativa { get; set; }
    public bool Status { get; set; } = true;
}
