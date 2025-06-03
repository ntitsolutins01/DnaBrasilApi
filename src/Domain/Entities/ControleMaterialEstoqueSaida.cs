namespace DnaBrasilApi.Domain.Entities;

public class ControleMaterialEstoqueSaida : BaseAuditableEntity
{
    public required Municipio Municipio { get; set; }
    public required Localidade Localidade { get; set; }
    public required Inventario Inventario { get; set; }
    public required int Quantidade { get; set; }
    public required Usuario Usuario { get; set; }
}
