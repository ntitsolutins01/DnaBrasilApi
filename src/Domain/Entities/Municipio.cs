using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class Municipio : BaseAuditableEntity
{
    public required int Codigo { get; set; }
    public required string? Nome { get; set; }
    public required Estado? Estado { get; set; }
}
