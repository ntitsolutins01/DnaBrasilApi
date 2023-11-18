using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasilApi.Domain.Entities;
public class PlanoAula : BaseAuditableEntity
{
    public string? Nome { get; set; }
    public string? Grade { get; set; }
    public string? Url { get; set; }
}
