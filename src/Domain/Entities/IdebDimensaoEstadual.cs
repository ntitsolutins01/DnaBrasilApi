using System.ComponentModel.DataAnnotations.Schema;

namespace DnaBrasilApi.Domain.Entities;
public class IdebDimensaoEstadual : BaseAuditableEntity
{
    public required EtapaEnsino EtapaEnsino { get; set; }
    public required Estado Estado { get; set; }
    public required string Ano { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? Media { get; set; }
    public bool Status { get; set; } = true;
}
