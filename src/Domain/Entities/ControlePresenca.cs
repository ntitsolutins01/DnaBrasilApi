namespace DnaBrasilApi.Domain.Entities;
public class ControlePresenca : BaseAuditableEntity
{
    public required Aluno Aluno { get; set; }
    public Evento? Evento { get; set; }
    public required string Controle { get; set; }
    public string? Justificativa { get; set; }
    public bool Status { get; set; } = true;
}
