namespace DnaBrasilApi.Domain.Entities;
public  class Encaminhamento : BaseAuditableEntity
{
    public required TipoLaudo TipoLaudo { get; set; }
    public required string Nome { get; set; }
    public required string Parametro { get; set; }
    public bool Status { get; set; } = true;
}
