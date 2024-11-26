namespace DnaBrasilApi.Domain.Entities;

public class Certificado : BaseAuditableEntity
{
    public required Curso Curso { get; set; }
    public required Byte[] ImgFrente { get; set; }
    public Byte[]? ImgVerso { get; set; }
    public required string HtmlFrente { get; set; }
    public required string HtmlVerso { get; set; }
    public bool Status { get; set; } = true;
}
