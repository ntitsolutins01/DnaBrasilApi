﻿namespace DnaBrasilApi.Domain.Entities;
public class QuestaoEad : BaseAuditableEntity
{
    public required string Enunciado { get; set;}
    public required string Referencia { get; set;}
    public required int Questao { get; set;}
    
}