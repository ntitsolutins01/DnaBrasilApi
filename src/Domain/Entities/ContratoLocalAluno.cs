using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class ContratoLocalAluno : BaseAuditableEntity
{
    public required ContratoLocal? ContratoLocal { get; set; }
    public required Aluno? Aluno { get; set; }
    public bool Status { get; set; }
}
