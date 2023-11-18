using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasilApi.Domain.Entities;
public class Serie : BaseAuditableEntity
{
    public required string Nome { get; set; }
    public required string Descricao { get; set; }
    public required int IdadeInicial { get; set; }
    public required int IdadeFinal { get; set; }
    public required int ScoreTotal { get; set; }
}
