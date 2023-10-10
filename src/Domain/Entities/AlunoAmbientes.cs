using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class AlunoAmbientes : BaseAuditableEntity
{
    public string? Ambiente { get; set; }
}
