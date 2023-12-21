using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasilApi.Domain.Entities;
public class TalentoEsportivo : BaseAuditableEntity
{
    public required Profissional Profissional { get; set; }
    public decimal? Flexibilidade { get; set; }
    public decimal? PreensaoManual { get; set; }
    public decimal? Velocidade { get; set; }
    public decimal? ImpulsaoHorizontal { get; set; }
    public decimal? AptidaoFisica { get; set; }
    public decimal? Agilidade { get; set; }
    public decimal? Abdominal { get; set; }
    public decimal? Imc { get; set; }
    public decimal? Quadrado { get; set; }
    public decimal? Encaminhamento { get; set; }
    public decimal? Altura { get; set; }
    public decimal? Peso { get; set; }
}
