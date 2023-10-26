using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class TalentoEsportivo : BaseAuditableEntity
{
    public required Profissional Profissional { get; set; }
    public int? Flexibilidade { get; set; }
    public int? PreensaoManual { get; set; }
    public int? Velocidade { get; set; }
    public int? ImpulsaoHorizontal { get; set; }
    public int? AptidaoFisica { get; set; }
    public int? Agilidade { get; set; }
    public int? Abdominal { get; set; }
    public required Aluno Aluno { get; set; }
}
