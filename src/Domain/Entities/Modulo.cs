using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class Modulo : BaseAuditableEntity
{
    public required string Nome { get; set; }
    public List<Funcionalidade>? Funcionalidades { get; set;}

}
