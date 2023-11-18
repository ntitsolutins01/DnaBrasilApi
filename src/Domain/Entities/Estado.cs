using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasilApi.Domain.Entities;
public class Estado : BaseAuditableEntity
{
    public string? Sigla { get; set;}
    public string? Nome { get; set; }
    public List<Municipio>? Municipios { get; set; }
}
