namespace DnaBrasil.Domain.Entities;
public class Aluno : BaseAuditableEntity
{
    public int AspNetUserId { get; set; }
    public required Municipio Municipio { get; set; }
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public required string Sexo { get; set; }
    public required DateTime DtNascimento { get; set; }
    public string NomeMae { get; set; } = null!;
    public string NomePai { get; set; } = null!;
    public string Cpf { get; set; } = null!;
    public string Telefone { get; set; } = null!;
    public string Celular { get; set; } = null!;
    public string Cep { get; set; } = null!;
    public string Endereco { get; set; } = null!;
    public string Numero { get; set; } = null!;
    public string Bairro { get; set; } = null!;
    public string RedeSocial { get; set; } = null!;
    public string Url { get; set; } = null!;
    public bool Status { get; set; }
    public bool Habilitado { get; set; }
    public List<Deficiencia> Deficiencias { get; } = new();
    public List<Ambiente> Ambientes { get; } = new();
}
