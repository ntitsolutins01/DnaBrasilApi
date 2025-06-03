namespace DnaBrasilApi.Domain.Entities;
public class Educacional : BaseAuditableEntity
{
    public required Profissional Profissional { get; set; }
    public required Aluno Aluno { get; set; }
    public required Serie Serie { get; set; }
    public required string Pdf { get; set; }
    public required string Respostas { get; set; }
    public Encaminhamento? Encaminhamento { get; set; }
    public string? StatusEducacional { get; set; }
}
