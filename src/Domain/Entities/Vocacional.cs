﻿namespace DnaBrasil.Domain.Entities;
public class Vocacional : BaseAuditableEntity
{
    public required Profissional Profissional { get; set; }
    public required Questionario Questionario { get; set; }
    public required string Resposta { get; set; }
}
