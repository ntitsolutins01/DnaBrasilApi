namespace DnaBrasilApi.Domain.Entities;
public class TextoLaudo : BaseAuditableEntity
{
    public TipoLaudo? TipoLaudo { get; set; }
    public string? Classificacao { get; set; }
    public decimal PontoInicial { get; set; }
    public decimal PontoFinal { get; set; }
    public string? Aviso { get; set; }
    public string? Texto { get; set; }
    public bool Status { get; set; } = true;
}
