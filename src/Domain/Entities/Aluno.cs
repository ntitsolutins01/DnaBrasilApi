namespace DnaBrasilApi.Domain.Entities;
public class Aluno : BaseAuditableEntity
{
    public string? AspNetUserId { get; set; }
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
    public string? Url { get; set; }
    public bool Status { get; set; }
    public bool Habilitado { get; set; }
    public required string? Etnia { get; set; }
    public int? IdCliente { get; set; }
    public required Municipio Municipio { get; set; }
    public required Localidade Localidade { get; set; }
    public List<Deficiencia>? Deficiencias { get; set; }
    public List<Ambiente>? Ambientes { get; set; }
    public Parceiro? Parceiro { get; set; }
    public List<Contrato>? Contratos { get; set; }
    public Matricula? Matricula { get; set; }
    public Voucher? Voucher { get; set; }
    public Dependencia? Dependencia { get; set; }
    public List<Laudo>? Laudos { get; set; }
    public Profissional? Profissional { get; set; }
}
