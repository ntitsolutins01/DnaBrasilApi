namespace DnaBrasilApi.Domain.Entities;
public class Fomentu : BaseAuditableEntity
{
    public required string Codigo { get; set; }
    public required string Nome { get; set; }
    public bool Status { get; set; } = true;
    public required Municipio? Municipio { get; set; }
    public required Localidade Localidade { get; set; }
    public required DateTime DtIni { get; set; }
    public required DateTime DtFim { get; set; }
    //public List<LinhaAcao>? LinhasAcoes { get; set; }
    public IList<FomentoLocalidade>? FomentoLocalidades { get; set; }
}
