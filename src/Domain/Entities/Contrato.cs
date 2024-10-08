﻿namespace DnaBrasilApi.Domain.Entities;
public class Contrato : BaseAuditableEntity
{
    public required string Nome { get; set; }
    public required string? Descricao { get; set; }
    public required DateTime DtIni { get; set; }
    public required DateTime DtFim { get; set; }
    public string? Anexo { get; set; }
    public bool Status { get; set; } = true;
    public List<Localidade>? Localidades { get; set; }
    public List<Aluno>? Alunos { get; set; }
    public List<Profissional>? Profissionais { get; set; }
}
