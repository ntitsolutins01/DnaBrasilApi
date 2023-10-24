using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class ContratoLocalAluno : BaseAuditableEntity
{
    public int IdContratoLocal { get; set; }
    public int IdAluno{ get; set; }
    public bool Status { get; set; }
    //public ContratoLocal? ContratoLocal { get; set; }
    //public Aluno? Aluno { get; set; }
}
