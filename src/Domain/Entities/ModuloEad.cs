namespace DnaBrasilApi.Domain.Entities;

public class ModuloEad : BaseAuditableEntity
{
    public required Curso Curso { get; set; }
    public required string Titulo { get; set; }    
    public string?  Descricao { get; set; }  
    public int? Ordem { get; set; }
    public bool Status { get; set; } = true;
}
