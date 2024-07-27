namespace DnaBrasilApi.Domain.Entities;

public class ConsumoAlimentar : BaseAuditableEntity
{
    public required Profissional Profissional { get; set; }
    public required Aluno Aluno { get; set; }
    public required string Resposta { get; set; }
    public string? StatusConsumoAlimentar { get; set; }
}
