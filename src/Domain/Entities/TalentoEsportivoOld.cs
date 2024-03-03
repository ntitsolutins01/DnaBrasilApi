using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasilApi.Domain.Entities;
public class TalentoEsportivo : BaseAuditableEntity
{
    public required Profissional Profissional { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Flexibilidade { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? PreensaoManual { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Velocidade { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? ImpulsaoHorizontal { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? AptidaoFisica { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Abdominal { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Imc { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Quadrado { get; set; }
    public string? Encaminhamento { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Altura { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Peso { get; set; }
}
