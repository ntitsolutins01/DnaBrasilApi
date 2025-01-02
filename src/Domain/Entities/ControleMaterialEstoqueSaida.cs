namespace DnaBrasilApi.Domain.Entities;

public class ControleMaterialEstoqueSaida : BaseAuditableEntity
{
    public required Material Material { get; set; }
    public required int Quantidade { get; set; }
    public string? Solicitante { get; set; }
}
