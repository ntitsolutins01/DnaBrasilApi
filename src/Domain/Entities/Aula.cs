namespace DnaBrasilApi.Domain.Entities;

public class Aula : BaseAuditableEntity
{
    public required Usuario Professor { get; set; }
    public required ModuloEad ModuloEad { get; set; }
    public required string Titulo { get; set; }
    public string? Descricao { get; set; }
    public bool Status { get; set; } = true;
    public string? Material { get; set; }
    public string? NomeMaterial { get; set; }
    public string? Video { get; set; }
    public string? NomeVideo { get; set; }
    public int? Ordem { get; set; }
    public IList<AlunoAula>? AlunoAulas { get; set; }
    public IList<QuestaoEad>? Questoes { get; set; }
}
