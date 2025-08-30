namespace DnaBrasilApi.Domain.Entities;

public class DocumentoAluno : BaseAuditableEntity
{
    public required Aluno Aluno { get; set; }
    public required string NomeDocumento { get; set; }
    public required string Url { get; set; }
    public bool Status { get; set; } = true;
}
