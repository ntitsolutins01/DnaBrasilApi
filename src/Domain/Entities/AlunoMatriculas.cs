using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaBrasil.Domain.Entities;
public class AlunoMatriculas : BaseAuditableEntity
{
    //combo localidade
    public DateTime DtVencPARQ { get; set; }
    public DateTime DtVencAtestadoMedico { get; set; }
    public string? NomePrimResponsavel { get; set; }
    public string? ParentescoPrimResponsavel { get; set; }
    public string? CpfPrimResponsavel { get; set; }
    public string? NomeSegResponsavel { get; set; }
    public string? ParentescoSegResponsavel { get; set; }
    public string? CpfSegResponsavel { get; set; }
    public string? NomeTerResponsavel { get; set; }
    public string? ParentescoTerResponsavel { get; set; }
    public string? CpfTerResponsavel { get; set; }
}
