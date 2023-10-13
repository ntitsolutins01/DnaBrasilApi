using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class Parceiro : BaseAuditableEntity
{
    public int AspNetUserId { get; set; }
    public required Municipio Municipio { get; set; }
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;      
    public int TipoParceria { get; set; }
    public string TipoPessoa { get; set; } = null!;
    public int CpfCnpj { get; set; }
    public string Telefone { get; set; } = null!;
    public string Celular { get; set; } = null!;
    public string Cep { get; set; } = null!;
    public string Endereco { get; set; } = null!;
    public int Numero { get; set; }
    public string Bairro { get; set; } = null!;
    public bool Status { get; set; }
    public bool Habilitado { get; set; }
}
