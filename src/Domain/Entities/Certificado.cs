namespace DnaBrasilApi.Domain.Entities;

public class Certificado : BaseAuditableEntity
{
    public required Fomentu Fomento { get; set; }
    public required string Nome { get; set; }
    public required string Url { get; set; }
    public bool Status { get; set; } = true;
    public IList<AlunoCursoCertificado>? AlunoCursosCertificados { get; set; }
}
