namespace DnaBrasilApi.Domain.Entities;

public class Ranking : BaseAuditableEntity
{
    public string? NomeRanking { get; set; }
    public bool Status { get; set; } = true;
}
