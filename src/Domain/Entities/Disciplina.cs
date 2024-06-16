using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasilApi.Domain.Entities;
public class Disciplina : BaseAuditableEntity
{
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public bool Status { get; set; } = true;
}
