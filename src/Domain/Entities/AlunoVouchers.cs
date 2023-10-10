using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class AlunoVouchers : BaseAuditableEntity
{
    public string? Voucher { get; set; }
    //combo local
    //public string? Turma { get; set; }
    //combo serie
}
