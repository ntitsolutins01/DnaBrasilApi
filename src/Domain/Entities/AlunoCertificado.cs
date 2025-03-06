namespace DnaBrasilApi.Domain.Entities;

public class AlunoCertificado : BaseAuditableEntity
{
    public required Aluno Aluno { get; set; }
    public required Certificado Certificado { get; set; }
}
