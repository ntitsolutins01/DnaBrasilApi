namespace DnaBrasilApi.Domain.Entities;
public  class ControleMaterial : BaseAuditableEntity
{
    public required LinhaAcao LinhaAcao { get; set; }
    public required string Descricao { get; set; }
    public required string UnidadeMedida { get; set; }
    public required int Quantidade { get; set; }
    public int? Saida { get; set; }
    public int? Disponivel { get; set; }
    public bool Status { get; set; } = true;
}
