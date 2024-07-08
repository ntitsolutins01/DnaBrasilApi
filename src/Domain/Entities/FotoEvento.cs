namespace DnaBrasilApi.Domain.Entities;

public class FotoEvento : BaseAuditableEntity
{
    public required Evento Evento { get; set; }
    public required string NomeArquivo { get; set; }
    public required string Url { get; set; }
    public bool Status { get; set; } = true;
}
