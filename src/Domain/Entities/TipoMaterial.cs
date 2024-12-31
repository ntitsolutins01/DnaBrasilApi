namespace DnaBrasilApi.Domain.Entities;

public class TipoMaterial : BaseAuditableEntity
{   
    public required GrupoMaterial GrupoMaterial { get; set; }
    public required string Nome { get; set; }
}
