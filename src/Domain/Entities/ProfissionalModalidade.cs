﻿namespace DnaBrasilApi.Domain.Entities;
public class ProfissionalModalidade 
{
    public int ProfissionalId { get; set; }
    public int ModalidadeId { get; set; }
    public Profissional Profissional { get; set; } = null!;
    public Modalidade Modalidade { get; set; } = null!;
}
