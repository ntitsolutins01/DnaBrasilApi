using System.ComponentModel.DataAnnotations.Schema;

namespace DnaBrasilApi.Domain.Entities;
public class LinhaAcao : BaseAuditableEntity
{
    public required string Nome { get; set; }
    public bool Status { get; set; }
    public List<Fomentu>? Fomentos { get; set; }
}
