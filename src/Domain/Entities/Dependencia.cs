﻿namespace DnaBrasilApi.Domain.Entities;
public class Dependencia : BaseAuditableEntity
{
    public string? Doencas { get; set; }
    public string? Nacionalidade { get; set; }
    public string? Naturalidade { get; set; }
    public string? NomeEscola { get; set; }
    public string? TipoEscola { get; set; }
    public string? TipoEscolaridade { get; set; }
    public string? Turno { get; set; }
    public string? Serie { get; set; }
    public string? Ano { get; set; }
    public string? Turma { get; set; }
    public bool? TermoCompromisso { get; set; }
    public bool? AutorizacaoUsoImagemAudio { get; set; }
    public bool? AutorizacaoUsoIndicadores { get; set; }
    public bool? AutorizacaoSaida { get; set; } = false;
    public Aluno? Aluno { get; set; }
}
