namespace DnaBrasilApi.Domain.Entities;

public class ArquivosInventario : BaseAuditableEntity
{
    public required Inventario Inventario { get; set; }
    public string? PathArquivo { get; set; }
    public string? NomeArquivo { get; set; }
}
