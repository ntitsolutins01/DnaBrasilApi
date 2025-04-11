namespace DnaBrasilApi.Domain.Entities;

public class Certificado : BaseAuditableEntity
{
    public required Fomentu Fomento { get; set; }
    public required string ImagemFrente { get; set; }
    public string? ImagemVerso { get; set; }
    public string? NomeImagemFrente { get; set; }
    public string? NomeImagemVerso { get; set; }
    public required string HtmlFrente { get; set; }
    public required string HtmlVerso { get; set; }
    public bool Status { get; set; } = true;
    public IList<AlunoCertificado>? AlunoCertificados { get; set; }
}
