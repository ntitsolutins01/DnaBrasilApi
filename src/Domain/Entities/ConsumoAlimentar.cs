﻿namespace DnaBrasilApi.Domain.Entities;

public class ConsumoAlimentar : BaseAuditableEntity
{
    public required Profissional Profissional { get; set; }
    public required Aluno Aluno { get; set; }
    public Encaminhamento? Encaminhamento { get; set; }
    public required string Respostas { get; set; }
    public string? StatusConsumoAlimentar { get; set; }
}
