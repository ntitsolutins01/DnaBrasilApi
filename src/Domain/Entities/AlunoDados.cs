using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class AlunoDados : BaseAuditableEntity
{
    public int AspNetUserId { get; set; }
    public required Estado Estado { get; set; }
    public required Municipio Municipio { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Senha { get; set; }
    public DateTime DtNascimento { get; set; }
    public string? NomeMae { get; set; }
    public string? NomePai { get; set; }
    public string? CPF { get; set; }
    public string? Telefone { get; set; }
    public string? Celular { get; set; }
    public string? CEP { get; set; }
    public string? Endereco { get; set; }
    public string? EnderecoNumero { get; set; }
    public string? Bairro { get; set; }
    public string? Social { get; set; }
    public bool Ativo { get; set; }
    public bool Habilitado { get; set; }
}
