using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class ContratoLocal : BaseAuditableEntity
{
    public required Local? Local { get; set; }
    public required Contrato? Contrato { get; set; }
}
