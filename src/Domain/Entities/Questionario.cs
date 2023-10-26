using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class Questionario : BaseAuditableEntity
{
    public required string Pergunta { get; set;}
    public required TipoLaudo Tipo { get; set; }
}
