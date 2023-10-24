using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class Contrato : BaseAuditableEntity
{
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public DateTime DtIni { get; set; }
    public DateTime DtFim { get; set; }
    public string? Anexo { get; set; }
    public bool Status { get; set; }
}
