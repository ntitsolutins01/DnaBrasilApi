using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class ContratoLocal : BaseAuditableEntity
{
    public int IdContrato { get; set; }
    public int Idlocal { get; set; }
    //public Local? Local { get; set; }
    //public Contrato? Contrato { get; set; }
}
