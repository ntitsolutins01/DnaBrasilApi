using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class Serie : BaseAuditableEntity
{
    public required string Nome { get; set; }
    public required string Descricao { get; set; }
    public int IdadeInicial { get; set; }
    public int IdadeFinal { get; set; }
    public int ScoreTotal { get; set; }
}
