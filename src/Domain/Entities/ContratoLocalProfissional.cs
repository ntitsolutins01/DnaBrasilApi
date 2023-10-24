using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class ContratoLocalProfissional : BaseAuditableEntity
{
    public int IdContratoLocal { get; set; }
    public int IdProfissional { get; set; }
    //public ContratoLocal? ContratoLocal { get; set; }
    //public Profissional? Profissional { get; set; }

}
