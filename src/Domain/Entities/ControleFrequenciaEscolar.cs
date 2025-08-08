namespace DnaBrasilApi.Domain.Entities;
public class ControleFrequenciaEscolar : BaseAuditableEntity
{
    public required string Controle { get; set; }
    public Aluno? Aluno { get; set; }
    public Serie? Serie { get; set; }
    public Disciplina? Disciplina { get; set; }
    public Profissional? Profissional { get; set; }
    public DateTime? DataFrequencia { get; set; }
}
