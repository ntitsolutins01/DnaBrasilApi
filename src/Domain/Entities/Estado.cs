namespace DnaBrasilApi.Domain.Entities;
public class Estado : BaseAuditableEntity
{
    public string? Sigla { get; set; }
    public string? Nome { get; set; }
    public List<Municipio>? Municipios { get; set; }
    public required int CodigoIbge { get; set; }
}
