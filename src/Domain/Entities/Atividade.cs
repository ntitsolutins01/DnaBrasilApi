namespace DnaBrasilApi.Domain.Entities;

public class Atividade : BaseAuditableEntity
{
    public required Estrutura Estrutura { get; set; }
    public required LinhaAcao LinhaAcao { get; set; }
    public required Categoria Categoria { get; set; }
    public required Modalidade Modalidade { get; set; }
    public string? Turma { get; set; }
    public TimeSpan? HrInicial { get; set; }
    public TimeSpan? HrFinal { get; set; }
    public required Profissional Profissional { get; set; }
    public required Localidade Localidade { get; set; }
}
