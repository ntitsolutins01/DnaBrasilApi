﻿namespace DnaBrasilApi.Domain.Entities;
public class Laudo : BaseAuditableEntity
{
    public TalentoEsportivo? TalentoEsportivo { get; set; }
    public Vocacional? Vocacional { get; set; }
    public QualidadeDeVida? QualidadeDeVida { get; set; }
    public string? StatusQualidadeDeVida { get; set; }
    public Saude? Saude { get; set; }
    public ConsumoAlimentar? Consumo { get; set; }
    public SaudeBucal? SaudeBucal { get; set; }
    public required Aluno Aluno { get; set; }
    public string? Encaminhamento { get; set; }
    public string? StatusLaudo { get; set; }
}
