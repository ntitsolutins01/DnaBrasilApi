namespace DnaBrasil.Domain.Entities;
public class Localidade : BaseAuditableEntity
{
    public required string? Nome { get; set; }
    public string? Descricao { get; set; }
    public bool Status { get; set; } =  true;
    public required Municipio? Municipio { get; set; }
    public required List<Contrato>? Contratos { get; set; }
}
