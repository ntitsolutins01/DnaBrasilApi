using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasilApi.Domain.Entities;

public class ConsumoAlimentar : BaseAuditableEntity
{
    public required Profissional? Profissional { get; set; }
    public required Questionario? Questionario { get; set; }
    public required string Resposta { get; set; }
}
