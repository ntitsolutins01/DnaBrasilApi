namespace DnaBrasilApi.Domain.Entities;
public class Vocacional : BaseAuditableEntity
{
    public required Profissional Profissional { get; set; }
    public required Aluno Aluno { get; set; }
    public required string Resposta { get; set; }
    public string? StatusVocacionail { get; set; }
}
