using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class SistemaSocioeconomico : BaseAuditableEntity
{
    public int AspNetUserId { get; set; }
    public required Estado Estado { get; set; }
    public required Municipio Municipio { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public int TipoParceria { get; set; }
    public string? TipoPessoa { get; set; }
    public int CpfCnpj { get; set; }
    public string? Telefone { get; set; }
    public string? Celular { get; set; }
    public string? CEP { get; set; }
    public string? Endereco { get; set; }
    public string? Numero { get; set; }
    public string? Bairro { get; set; }
    public bool Status { get; set; }
    public bool Habilitado { get; set; }
}
