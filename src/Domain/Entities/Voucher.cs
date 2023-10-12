using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class Voucher : BaseAuditableEntity
{
    public Local Local { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public string Turma { get; set; } = null!;
    public string Serie { get; set; } = null!;
}
