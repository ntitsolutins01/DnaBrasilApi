using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class SaudeBucal : BaseAuditableEntity
{
    public required Profissional Profissional { get; set; }
    public string? Descricao { get; set; }
    public string? Resposta { get; set; }
}
