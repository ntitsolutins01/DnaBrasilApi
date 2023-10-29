namespace DnaBrasil.Application.Alunos.Queries;
public class SearchAlunosDto
{
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public bool? Status { get; set; }
    public int? DeficienciaId { get; set;}
    public int? LocalId { get;}
}
