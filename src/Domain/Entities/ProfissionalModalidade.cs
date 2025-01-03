namespace DnaBrasilApi.Domain.Entities;
public class ProfissionalModalidade : BaseAuditableEntity
{
    public int ProfissionalId { get; set; }
    public int ModalidadeId { get; set; }
    public required Profissional Profissional { get; set; }
    public required Modalidade Modalidade { get; set; }
}
