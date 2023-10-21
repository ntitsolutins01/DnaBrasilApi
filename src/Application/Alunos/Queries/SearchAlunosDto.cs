namespace DnaBrasil.Application.Alunos.Queries;
public class SearchAlunosDto
{
    public string? Nome { get; set; }
    public required string Cpf { get; set; }
    public bool Status { get; set; }
    public bool Habilitado { get; set; }
}
