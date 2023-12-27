using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasilApi.Domain.Entities;
public class Profissional : BaseAuditableEntity
{
    public string? AspNetUserId { get; set; }
    public required string Nome { get; set; }
    public DateTime? DtNascimento { get; set; }
    public required string Email { get; set; }
    public string? Sexo { get; set; }
    public required string CpfCnpj { get; set; }
    public string? Telefone { get; set; }
    public string? Celular { get; set; }
    public string? Endereco { get; set; }
    public int? Numero { get; set; }
    public string? Cep { get; set; }
    public string? Bairro { get; set; }
    public bool Status { get; set; } = true;
    public bool Habilitado { get; set; } = false;
    public Municipio? Municipio { get; set; }
    public List<Ambiente>? Ambientes { get; set; }
    public List<Contrato>? Contratos { get; set; }
}
