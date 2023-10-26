using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class Saude : BaseAuditableEntity
{
    public required Profissional Profissional { get; set; }
    public int? Altura { get; set; }
    public int Massa { get; set; }
    public int? Envergadura { get; set; }
    public required Aluno Aluno { get; set; }
}
