namespace DnaBrasilApi.Domain.Entities;
public class QualidadeDeVida : BaseAuditableEntity
{
    public required Profissional Profissional { get; set; }
    public required Aluno Aluno { get; set; }
    public string? Encaminhamentos { get; set; }
    public required string Respostas { get; set; }
    public string? StatusQualidadeDeVida { get; set; }
}
