namespace DnaBrasil.Domain.Entities;
public class Localidade : BaseAuditableEntity
{
    public required string? Nome { get; set; }
    public string? Descricao { get; set; }
    public bool Status { get; set; } =  true;
    public  Municipio? Municipio { get; set; }
    public  List<Contrato>? Contratos { get; set; }
}
