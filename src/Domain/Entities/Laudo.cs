namespace DnaBrasil.Domain.Entities;
public class Laudo : BaseAuditableEntity
{
    public TalentoEsportivo? TalentoEsportivo { get; set; }
    public Vocacional? Vocacional { get; set; }
    public QualidadeDeVida? QualidadeDeVida { get; set; }
    public Saude? Saude { get; set; }
    public ConsumoAlimentar? Consumo { get; set; }
    public SaudeBucal? SaudeBucal { get; set; }
    public List<Aluno>? Alunos { get; set; }

}
