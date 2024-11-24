namespace DnaBrasilApi.Domain.Entities;

public class Aula : BaseAuditableEntity
{
    public required int CargaHoraria { get; set; }
    public required Usuario Professor { get; set; }
    public required ModuloEad ModuloEad { get; set; }
    public required string Titulo { get; set; }    
    public string?  Descricao { get; set; }  
    public bool Status { get; set; } = true;
    public string? Material { get; set; }
    public string? NomeMaterial { get; set; }
    public string? Video { get; set; }
}
