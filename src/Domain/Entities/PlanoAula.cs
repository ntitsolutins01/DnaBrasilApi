namespace DnaBrasilApi.Domain.Entities;
public class PlanoAula : BaseAuditableEntity
{
    public string? Nome { get; set; }
    public string? TipoEscolaridade { get; set; }
    public string? Modalidade { get; set; }
    public string? Url { get; set; }
    public string? NomeArquivo { get; set; }
}
