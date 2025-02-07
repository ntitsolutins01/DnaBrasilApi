using System.ComponentModel.DataAnnotations.Schema;

namespace DnaBrasilApi.Domain.Entities;
public class ModeloCarteirinha : BaseAuditableEntity
{
    public required Fomentu Fomento { get; set; }
    public string? NomeImagem { get; set; }
    public string? UrlImagem { get; set; }
}
