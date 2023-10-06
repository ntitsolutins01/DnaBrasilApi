using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class Municipio
{
    public int IdEstado { get; set; }
    public int Codigo { get; set; }
    public string? Nome { get; set; }
}
