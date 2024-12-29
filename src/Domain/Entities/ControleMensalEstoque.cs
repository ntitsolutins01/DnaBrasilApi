﻿namespace DnaBrasilApi.Domain.Entities;

public class ControleMensalEstoque : BaseAuditableEntity
{
    public required Material Material { get; set; }
    public  int? QtdPrevista { get; set; }
    public DateTime? DataMesSaida { get; set; }
    public int? TotalSaidas { get; set; }    
    public int? TotalEstoque { get; set; }  
    public int? QtdMateriaisDanificadosExtraviados { get; set; }
    public string? JustificativaDanificadosExtraviados { get; set; }
    public DateTime? DataDanificadosExtraviados { get; set; }
}