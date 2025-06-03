namespace DnaBrasilApi.Domain.Entities;
public class Serie : BaseAuditableEntity
{
    public required string Nome { get; set; }
    public required string Turma { get; set; }
    public required EtapaEnsino EtapaEnsino { get; set; }
    public required Localidade Localidade { get; set; }
    public bool Status { get; set; } = true;
}
