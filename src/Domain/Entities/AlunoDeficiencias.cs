using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class AlunoDeficiencias : BaseAuditableEntity
{
    public string? Deficiencia { get; set; }
}
