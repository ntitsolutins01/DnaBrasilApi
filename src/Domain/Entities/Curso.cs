namespace DnaBrasilApi.Domain.Entities;

public class Curso : BaseAuditableEntity
{
    public required TipoCurso TipoCurso { get; set; }
    public required Usuario Usuario { get; set; }
    public required string Titulo { get; set; }
    public required int CargaHoraria { get; set; }
    public string? Descricao { get; set; }
    public bool Status { get; set; } = true;
}
