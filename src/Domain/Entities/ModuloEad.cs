namespace DnaBrasilApi.Domain.Entities;

public class ModuloEad : BaseAuditableEntity
{
    public required int CargaHoraria { get; set; }
    public required Curso Curso { get; set; }
    public required string Titulo { get; set; }    
    public string?  Descricao { get; set; }  
    public bool Status { get; set; } = true;
    public required string Nome { get; set; }
}
