using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class ContratoLocalProfissional : BaseAuditableEntity
{
    public required ContratoLocal? ContratoLocal { get; set; }
    public required Profissional? Profissional { get; set; }
}
