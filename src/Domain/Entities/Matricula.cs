namespace DnaBrasil.Domain.Entities;
public class Matricula : BaseAuditableEntity
{
    public DateTime DtVencimentoParq { get; set; }
    public DateTime DtVencimentoAtestadoMedico { get; set; }
    public string NomeResponsavel1 { get; set; } = null!;
    public string ParentescoResponsavel1 { get; set; } = null!;
    public string CpfResponsavel1 { get; set; } = null!;
    public string NomeResponsavel2 { get; set; } = null!;
    public string ParentescoResponsavel2 { get; set; } = null!; 
    public string CpfResponsavel2 { get; set; } = null!;
    public string NomeResponsavel3 { get; set; } = null!;
    public string ParentescoResponsavel3 { get; set; } = null!;
    public string CpfResponsavel3 { get; set; } = null!;
    public Local Local { get; set; } = null!;
}
