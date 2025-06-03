namespace DnaBrasilApi.Domain.Entities;
public class ModeloCarteirinha : BaseAuditableEntity
{
    public required Fomentu Fomento { get; set; }
    public string? NomeImagemFrente { get; set; }
    public string? UrlImagemFrente { get; set; }
    public string? NomeImagemVerso { get; set; }
    public string? UrlImagemVerso { get; set; }
}
