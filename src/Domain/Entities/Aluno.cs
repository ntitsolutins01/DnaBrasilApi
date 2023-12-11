namespace DnaBrasilApi.Domain.Entities;
public class Aluno : BaseAuditableEntity
{
    public Municipio? Municipio { get; set; }
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
    public List<Contrato>? Contratos { get; set; }
    public Matricula? Matricula { get; set; }
    public Voucher? Voucher { get; set; }
    public Dependencia? Dependencia { get; set; }
    public List<Laudo>? Laudos { get; set; }
}
