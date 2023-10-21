namespace DnaBrasil.Domain.Entities;
public class Aluno : BaseAuditableEntity
{
    public required int AspNetUserId { get; set; }
    public Municipio? Municipio { get; set; }
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public required string Sexo { get; set; }
    public required DateTime DtNascimento { get; set; }
    public string? NomeMae { get; set; }
    public string? NomePai { get; set; }
    public string? Cpf { get; set; }
    public string? Telefone { get; set; }
    public string? Celular { get; set; }
    public string? Cep { get; set; }
    public string? Endereco { get; set; }
    public string? Numero { get; set; }
    public string? Bairro { get; set; }
    public string? RedeSocial { get; set; }
    public string? Url { get; set; }
    public bool Status { get; set; }
    public bool Habilitado { get; set; }
    public List<Deficiencia>? Deficiencias { get; set; } = new();
    public List<Ambiente>? Ambientes { get; set; } = new();
    public Parceiro? Parceiro { get; set; }
}
